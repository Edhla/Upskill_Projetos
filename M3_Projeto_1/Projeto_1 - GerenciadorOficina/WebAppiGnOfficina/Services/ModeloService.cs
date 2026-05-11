using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;

namespace WebAppiGnOfficina.Services
{
    public class ModeloService: IModeloService
    {
        private readonly IModeloRepository _repo;

        public ModeloService(IModeloRepository repo)
        {
            _repo = repo;
            _repo.setDataBase("DB_GerenciadorOficinaTeste");
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

        public int Insert(Modelo marca)
        {
            return 0;
        }

        public void Update(Modelo marca)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
