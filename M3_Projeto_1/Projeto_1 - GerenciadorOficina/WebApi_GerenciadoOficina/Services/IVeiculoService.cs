using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public interface IVeiculoService
    {
        List<Veiculo> GetAll();
        Veiculo GetById(int id);

        int Insert(Veiculo veiculo, SqlTransaction trans);

        void Update(Veiculo veiculo, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
