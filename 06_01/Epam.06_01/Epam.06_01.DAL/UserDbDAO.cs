using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using Epam._06_01.Handlers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.DAL
{
    public class UserDbDAO : IUserDAO
    {

        private static Dictionary<uint, User> _users = new Dictionary<uint, User>();
        private static bool _edited = true;
        static readonly string path = DataMode.GetPath("DBconnection");

        public bool Add(User user)
        {
            if (_edited) { GetAll(); }
            var lastId = _users.Keys.Count > 0
            ? _users.Keys.Max()
            : 0;
            user.Id = lastId + 1;
            _users.Add(user.Id, user);
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";
                var nameParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = user.Name,
                    Direction = ParameterDirection.Input
                };
                var birthParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@datebirth",
                    Value = user.DateOfBirth,
                    Direction = ParameterDirection.Input
                };
                var idParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = user.Id,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParametr);
                command.Parameters.Add(nameParametr);
                command.Parameters.Add(birthParametr);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteAward(uint idUser, uint idAward)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUserAward";
                var idParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@userId",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                var idAwardParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@awardId",
                    Value = idAward,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);
                command.Parameters.Add(idAwardParametr);
                connection.Open();
                command.ExecuteNonQuery();
                _edited = true;
            }
            return true;
        }

        public bool DeleteById(uint id)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUser";
                var idParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@userId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);
                connection.Open();
                command.ExecuteNonQuery();
                _edited = true;
            }
            return true;
        }

        public bool EditUser(uint idUser, string newValue, DateTime newBirthday, List<uint> newAwards)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.UpdateUser";
                    var idParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@userId",
                        Value = idUser,
                        Direction = ParameterDirection.Input
                    };
                    var nameParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@newName",
                        Value = newValue,
                        Direction = ParameterDirection.Input
                    };
                    var BirthParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@newBirthdate",
                        Value = newBirthday,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(idParametr);
                    command.Parameters.Add(nameParametr);
                    command.Parameters.Add(BirthParametr);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                foreach (uint item in newAwards)
                {
                    GrantUserAwards(idUser, item);
                }
                _edited = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            _users.Clear();
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                    while (reader.Read())
                {
                    User newUser = new User();

                    int newId = (int)reader["id"];
                    newUser.Id = (uint)newId;
                    newUser.Name = reader["name"] as string;
                    newUser.DateOfBirth = (DateTime)reader["birthdate"];
                    _users.Add(newUser.Id, newUser);
                }
            }
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UserAwards";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int userId = (int)reader["id_user"];
                    int awardId = (int)reader["id_award"];
                    _users.FirstOrDefault(s=>s.Key==userId).Value.Awards.Add((uint)awardId);
                }
            }
            _edited = false;
            return _users.Values;
        }

        public User GetById(uint id)
        {
            if (_edited)
            {
                return GetAll().FirstOrDefault(s => s.Id == id);
            }
            return _users.FirstOrDefault(s => s.Key == id).Value;
        }

        public List<uint> GetUserAwards(uint id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id).Awards;
        }

        public bool GrantUserAwards(uint idUser, uint idAward)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GrantAward";
                var userId = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@userId",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                var awardId = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@awardId",
                    Value = idAward,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(userId);
                command.Parameters.Add(awardId);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
