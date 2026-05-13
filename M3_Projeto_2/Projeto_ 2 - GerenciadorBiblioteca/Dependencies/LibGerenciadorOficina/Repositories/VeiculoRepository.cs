using LibDB;
using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        internal string ConnectionString = "";
        public void setDataBase(string tagRepo)
        {
            ConnectionString = Conection2Repo.GetRepoConection(tagRepo);
        }
        public List<Veiculo> GetAll()
        {
            DALPro.ConnectionString = ConnectionString;
            string query = "SELECT * FROM Veiculo";

            return DALPro.Query<Veiculo>(query);

        }
        public Veiculo GetById(int id)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = "SELECT * FROM Veiculo WHERE Id=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            return DALPro.Query<Veiculo>(sql, param).FirstOrDefault();
        }

        public int Insert(Veiculo veiculo)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = @"INSERT INTO Veiculo
                        (Marca,Modelo,Ano,UltimaInspecao,Estado)
                        VALUES
                        (@Marca,@Modelo,@Ano,@UltimaInspecao,@Estado);
                        SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
        {
            {"@Marca", veiculo.Marca},
            {"@Modelo", veiculo.Modelo},
            {"@Ano", veiculo.Ano},
            {"@UltimaInspecao", veiculo.UltimaInspecao},
            {"@Estado", veiculo.Estado}
        };

            return TransactionHelper.ExecuteScalar(sql, param);

        }

        public void Update(Veiculo veiculo)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = @"UPDATE Veiculo
                         SET Marca = @Marca,
                         Modelo = @Modelo,
                         Ano = @Ano,
                         UltimaInspecao = @UltimaInspecao,
                         Estado = @Estado
                         WHERE ID = @IdVeiculo;";

            var param = new Dictionary<string, object>
            {
                {"@IdVeiculo", veiculo.Id},
                {"@Marca", veiculo.Marca},
                {"@Modelo", veiculo.Modelo},
                {"@Ano", veiculo.Ano},
                {"@UltimaInspecao", veiculo.UltimaInspecao},
                {"@Estado", veiculo.Estado}
            };
            TransactionHelper.Execute(sql, param);

        }

        public void Delete(int id)
        {
            DALPro.ConnectionString = ConnectionString;
            string sql = "DELETE FROM Veiculo WHERE Id=@id";

            var param = new Dictionary<string, object>
            {
                {"@id", id}
            };

            TransactionHelper.Execute(sql, param);
        }
    }
}
