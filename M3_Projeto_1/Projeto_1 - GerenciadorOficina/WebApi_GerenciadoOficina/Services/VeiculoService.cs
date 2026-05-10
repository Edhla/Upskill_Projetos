using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public class VeiculoService: IVeiculoService
    {
        public VeiculoService(string tagRepo)
        {

        }
        public List<Veiculo> GetAll()
        {
            List<Veiculo> marcas = new List<Veiculo>();

            return marcas;
        }
        public Veiculo GetById(int id)
        {
            Veiculo marca = null;

            return marca;

        }

        public int Insert(Veiculo marca, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Veiculo marca, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
