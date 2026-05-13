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

        int Insert(Modelo modelo);

        void Update(Modelo modelo);

        void Delete(int id);
    }
}
