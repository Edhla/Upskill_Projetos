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
        public void setDataBase(string tagRepo)
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

        public int Insert(Modelo modelo)
        {
            string sql = @"INSERT INTO Modelo
                       (NomeModelo) VALUES (@NomeModelo);
                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
            {
                {"@NomeModelo", modelo.NomeModelo}
            };

            return TransactionHelper.ExecuteScalar(sql, param);
        }

        public void Update(Modelo modelo)
        {
            string sql = @"UPDATE Modelo
                         SET NomeModelo = @NomeModelo
                         WHERE ID = @IdMarca;";

            var param = new Dictionary<string, object>
            {
                {"@NomeModelo", modelo.NomeModelo},
                {"@IdMarca", modelo.ID}
            };

            TransactionHelper.Execute(sql, param);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Modelo WHERE ID=@id";

            var param = new Dictionary<string, object>
            {
                {"@id", id}
            };

            TransactionHelper.Execute(sql, param);
        }
    }
}
