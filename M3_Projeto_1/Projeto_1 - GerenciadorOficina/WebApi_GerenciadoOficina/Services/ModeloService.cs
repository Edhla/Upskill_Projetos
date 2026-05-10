using LibGerenciadorOficina.Models;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public class ModeloService: IModeloService
    {
        public ModeloService(string tagRepo)
        {

        }
        public List<Modelo> GetAll()
        {
            List<Modelo> marcas = new List<Modelo>();

            return marcas;
        }
        public Modelo GetById(int id)
        {
            Modelo marca = null;

            return marca;

        }

        public int Insert(Modelo marca, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Modelo marca, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
