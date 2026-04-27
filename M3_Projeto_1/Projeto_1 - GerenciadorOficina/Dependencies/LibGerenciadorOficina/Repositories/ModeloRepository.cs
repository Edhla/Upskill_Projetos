using LibDB;
using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        public List<Modelo> GetAll(string tagRepo = "DB_GerenciadorOficinaTeste")
        {
            DALPro.ConnectionString = Conection2Repo.GetRepoConection(tagRepo);
            string query = "SELECT * FROM Modelo";

            return DALPro.Query<Modelo>(query);

        }
        public Modelo GetById(int id)
        {
            Modelo teste = new Modelo();
            return teste;
        }

        public int Insert(Modelo modelo, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Modelo modelo, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
