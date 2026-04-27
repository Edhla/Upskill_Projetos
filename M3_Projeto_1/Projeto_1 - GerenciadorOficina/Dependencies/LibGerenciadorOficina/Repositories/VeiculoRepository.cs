using LibDB;
using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        internal string ConnectionString = "";
        public VeiculoRepository(string tagRepo) 
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
            string sql = "SELECT * FROM Veiculo WHERE ProductID=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            return DALPro.Query<Veiculo>(sql, param).FirstOrDefault();
        }

        public int Insert(Veiculo veiculo, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Veiculo veiculo, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
