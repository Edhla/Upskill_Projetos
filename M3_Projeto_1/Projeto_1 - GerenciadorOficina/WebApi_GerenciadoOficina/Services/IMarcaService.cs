using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public interface IMarcaService
    {
        List<Marca> GetAll();
        Marca GetById(int id);

        int Insert(Marca marca, SqlTransaction trans);

        void Update(Marca marca, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
