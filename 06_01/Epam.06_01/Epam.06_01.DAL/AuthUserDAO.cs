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
    public class AuthUserDAO: IAuthUserDAO
    {
        private Dictionary<uint, AuthUser> _authUsers = new Dictionary<uint, AuthUser>();
        static readonly string path = DataMode.GetPath("DBconnection");

        public IEnumerable<AuthUser> GetAll()
        {
            _authUsers.Clear();
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAuthUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AuthUser newAuthUser = new AuthUser();

                    int newId = (int)reader["id"];
                    newAuthUser.Id = (uint)newId;
                    newAuthUser.Name = reader["name"] as string;
                    newAuthUser.IsAdmin = (bool)reader["admin"];
                    _authUsers.Add(newAuthUser.Id, newAuthUser);
                }
            }
            return _authUsers.Values;
        }
        public AuthUser GetById(uint id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }
        public AuthUser GetByName(string name)
        {
            return GetAll().FirstOrDefault(s => s.Name == name);
        }
        public bool EditById(uint id, string newValue, bool isadmin)
        {
            if (GetAll().FirstOrDefault(s => s.Name == newValue) != null)
            {
                return false;
            }
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAuthUser";
                var nameParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@newName",
                    Value = newValue,
                    Direction = ParameterDirection.Input
                };
                var idParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                var isAdminParametr = new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = "@IsAdmin",
                    IsNullable = true,
                    Value = isadmin,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(isAdminParametr);
                command.Parameters.Add(idParametr);
                command.Parameters.Add(nameParametr);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        public bool Registrate(AuthUser authUser)
        {
            GetAll();
            try
            {
                var lastId = _authUsers.Keys.Count > 0
                ? _authUsers.Keys.Max()
                : 0;
                authUser.Id = lastId + 1;
                _authUsers.Add(authUser.Id, authUser);
                if (GetAll().FirstOrDefault(s => s.Name == authUser.Name)!=null)
                {
                    return false;
                }
                using (SqlConnection connection = new SqlConnection(path))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddAuthUsers";
                    var nameParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@name",
                        Value = authUser.Name,
                        Direction = ParameterDirection.Input
                    };
                    var idParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@Id",
                        Value = authUser.Id,
                        Direction = ParameterDirection.Output
                    };
                    var isAdminParametr = new SqlParameter()
                    {
                        DbType = DbType.Boolean,
                        ParameterName = "@isAdmin",
                        Value = authUser.IsAdmin,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(isAdminParametr);
                    command.Parameters.Add(idParametr);
                    command.Parameters.Add(nameParametr);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
