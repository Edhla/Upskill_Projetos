using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public interface IVeiculoRepository
    {
        void setDataBase(string tagRepo);
        List<Veiculo> GetAll();
        Veiculo GetById(int id);

        int Insert(Veiculo veiculo);

        void Update(Veiculo veiculo);

        void Delete(int id);
    }
}
