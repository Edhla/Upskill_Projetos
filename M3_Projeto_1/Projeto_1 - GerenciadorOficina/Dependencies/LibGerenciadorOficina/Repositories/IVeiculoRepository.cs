using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public interface IVeiculoRepository
    {
        List<Veiculo> GetAll();
        Veiculo GetById(int id);

        int Insert(Veiculo veiculo, SqlTransaction trans);

        void Update(Veiculo veiculo, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
