using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;

namespace WebAppiGnOfficina.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repo;
        public MarcaService(IMarcaRepository repo)
        {
            _repo = repo;
            _repo.setDataBase("DB_GerenciadorOficinaTeste");

        }
        public List<MarcaDTO> GetAll()
        {
            return _repo.GetAll()
                .Select(marca => new MarcaDTO
                {
                    ID = marca.ID,
                    NomeMarca = marca.NomeMarca
                }).ToList();
        }
        public Marca GetById(int id)
        {
            Marca marca = null;

            return marca;

        }

        public int Insert(Marca marca)
        {
            return 0;
        }

        public void Update(Marca marca)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
