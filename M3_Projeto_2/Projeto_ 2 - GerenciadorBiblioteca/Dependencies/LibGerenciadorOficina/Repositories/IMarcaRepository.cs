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

        int Insert(Marca marca);

        void Update(Marca marca);

        void Delete(int id);
    }
}
