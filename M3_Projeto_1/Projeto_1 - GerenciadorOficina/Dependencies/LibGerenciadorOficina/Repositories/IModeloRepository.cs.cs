using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public interface IModeloRepository
    {
        void setDataBase(string tagRepo);
        List<Modelo> GetAll();
        Modelo GetById(int id);

        int Insert(Modelo modelo, SqlTransaction trans);

        void Update(Modelo modelo, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
