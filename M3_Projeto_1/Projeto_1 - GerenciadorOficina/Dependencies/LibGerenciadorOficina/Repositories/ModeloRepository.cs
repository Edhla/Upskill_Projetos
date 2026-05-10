using LibDB;
using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LibGerenciadorOficina.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        internal string ConnectionString = "";
        public ModeloRepository(string tagRepo)
        {
            ConnectionString = Conection2Repo.GetRepoConection(tagRepo);
        }
        public List<Modelo> GetAll()
        {
            DALPro.ConnectionString = ConnectionString;
            string query = "SELECT * FROM Modelo";

            return DALPro.Query<Modelo>(query);

        }
        public Modelo GetById(int id)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = "SELECT * FROM Modelo WHERE ID=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            return DALPro.Query<Modelo>(sql, param).FirstOrDefault();

        }

        public int Insert(Modelo modelo, SqlTransaction trans)
        {
            string sql = @"INSERT INTO Modelo
                       (NomeModelo) VALUES (@NomeModelo);
                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
            {
                {"@NomeModelo", modelo.NomeModelo}
            };

            return Convert.ToInt32(DALPro.ExecuteScalar(sql, param, trans));

        }

        public void Update(Modelo modelo, SqlTransaction trans)
        {
            string sql = @"INSERT INTO Modelo
                       (NomeModelo) VALUES (@NomeModelo);
                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
            {
                {"@NomeModelo", modelo.NomeModelo}
            };

            DALPro.Execute(sql, param, trans);

        }

        public void Delete(int id, SqlTransaction trans)
        {
            string sql = "DELETE FROM Modelo WHERE ID=@id";

            var param = new Dictionary<string, object>
            {
                {"@id", id}
            };

            DALPro.Execute(sql, param, trans);
        }
    }
}
