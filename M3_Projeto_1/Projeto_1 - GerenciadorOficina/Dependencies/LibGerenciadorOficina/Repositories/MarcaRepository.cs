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
        public List<Marca> GetAll(string tagRepo = "DB_GerenciadorOficinaTeste")
        {
            DALPro.ConnectionString = Conection2Repo.GetRepoConection(tagRepo);
            string query = "SELECT * FROM Marca";

            return DALPro.Query<Marca>(query);
        }
        public Marca GetById(int id)
        {
            Marca teste = new Marca();
            return teste;
        }

        public int Insert(Marca marca, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Marca marca, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
