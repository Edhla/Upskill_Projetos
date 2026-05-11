using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public interface IMarcaRepository
    {
        void setDataBase(string tagRepo);
        List<Marca> GetAll();
        Marca GetById(int id);

        int Insert(Marca marca, SqlTransaction trans);

        void Update(Marca marca, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
