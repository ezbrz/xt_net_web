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
    public class AwardDbDAO : IAwardDAO
    {
        private static Dictionary<uint, Award> _awards = new Dictionary<uint, Award>();
        private static bool _edited = true;
        static readonly string path = DataMode.GetPath("DBconnection");
        public bool Add(Award award)
        {
            if (_edited) { GetAll(); }
            try
            {
                var lastId = _awards.Keys.Count > 0
                ? _awards.Keys.Max()
                : 0;
                award.Id = lastId + 1;
                _awards.Add(award.Id, award);

                using (SqlConnection connection = new SqlConnection(path))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddAward";
                    var nameParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@name",
                        Value = award.Name,
                        Direction = ParameterDirection.Input
                    };
                    var idParametr = new SqlParameter()
                    {
                        DbType = DbType.String,
                        ParameterName = "@Id",
                        Value = award.Id,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idParametr);
                    command.Parameters.Add(nameParametr);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                _edited = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteById(uint id)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAward";
                var idParametr = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@awardId",
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

        public bool EditById(uint id, string newValue)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAward";
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
                    ParameterName = "@awardId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParametr);
                command.Parameters.Add(nameParametr);
                connection.Open();
                command.ExecuteNonQuery();
                _edited = true;
            }
            return true;
        }

        public IEnumerable<Award> GetAll()
        {
            _awards.Clear();
            using (SqlConnection connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwards";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Award newAward = new Award();

                    int newId = (int)reader["id"];
                    newAward.Id = (uint)newId;
                    newAward.Name = reader["name"] as string;
                    _awards.Add(newAward.Id, newAward);
                }
            }
            _edited = false;
            return _awards.Values;
        }

        public Award GetById(uint id)
        {
            if (_edited)
            {
                return GetAll().FirstOrDefault(s => s.Id == id);
            }
            return _awards.FirstOrDefault(s => s.Key == id).Value;
        }
    }
}
