using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;

namespace WebAppiGnOfficina.Services
{
    public class VeiculoService: IVeiculoService
    {
        private readonly IVeiculoRepository _repo;

        public VeiculoService(IVeiculoRepository repo)
        {
            _repo = repo;
            _repo.setDataBase("DB_GerenciadorOficinaTeste");
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

        public int Insert(Veiculo marca)
        {
            return 0;
        }

        public void Update(Veiculo marca)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
