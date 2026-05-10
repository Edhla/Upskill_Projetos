using LibDB;
using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public class MarcaRepository: IMarcaRepository
    {
        internal string ConnectionString = "";
        public MarcaRepository(string tagRepo)
        {
            ConnectionString = Conection2Repo.GetRepoConection(tagRepo);
        }
        public List<Marca> GetAll()
        {
            DALPro.ConnectionString = ConnectionString;

            string query = "SELECT * FROM Marca";

            return DALPro.Query<Marca>(query);
        }
        public Marca GetById(int id)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = "SELECT * FROM Marca WHERE ID=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            return DALPro.Query<Marca>(sql, param).FirstOrDefault();

        }

        public int Insert(Marca marca, SqlTransaction trans)
        {
            string sql = @"INSERT INTO Marca
                       (NomeMarca) VALUES (@NomeMarca);
                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
        {
            {"@NomeMarca", marca.NomeMarca}
        };

            return Convert.ToInt32(DALPro.ExecuteScalar(sql, param, trans));
        }

        public void Update(Marca marca, SqlTransaction trans)
        {
            string sql = @"INSERT INTO Marca
                       (NomeMarca) VALUES (@NomeMarca);
                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
        {
            {"@NomeMarca", marca.NomeMarca}
        };
            DALPro.Execute(sql, param, trans);

        }

        public void Delete(int id, SqlTransaction trans)
        {
            string sql = "DELETE FROM Marca WHERE ID=@id";

            var param = new Dictionary<string, object>
            {
                {"@id", id}
            };

            DALPro.Execute(sql, param, trans);
        }
    }
}
