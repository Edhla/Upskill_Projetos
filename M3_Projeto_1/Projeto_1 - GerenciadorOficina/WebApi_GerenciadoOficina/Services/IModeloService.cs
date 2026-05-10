using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public interface IModeloService
    {
        List<Modelo> GetAll();
        Modelo GetById(int id);

        int Insert(Modelo modelo, SqlTransaction trans);

        void Update(Modelo modelo, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
