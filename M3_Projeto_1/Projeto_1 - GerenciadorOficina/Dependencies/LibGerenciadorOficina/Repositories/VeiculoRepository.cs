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

        public int Insert(Veiculo veiculo, SqlTransaction trans)
        {
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

            return Convert.ToInt32(DALPro.ExecuteScalar(sql, param, trans));

        }

        public void Update(Veiculo veiculo, SqlTransaction trans)
        {
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
            DALPro.Execute(sql, param, trans);

        }

        public void Delete(int id, SqlTransaction trans)
        {
            string sql = "DELETE FROM Veiculo WHERE Id=@id";

            var param = new Dictionary<string, object>
            {
                {"@id", id}
            };

            DALPro.Execute(sql, param, trans);
        }
    }
}
