using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;
using Microsoft.Data.SqlClient;

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
        public MarcaDTO GetById(int id)
        {
            var m = _repo.GetById(id);

            if (m == null)
            {
                return null;
            }

            return new MarcaDTO
            {
                ID = m.ID,
                NomeMarca = m.NomeMarca
            };
        }

        public int Insert(MarcaDTO marca)
        {
            try
            {
                Marca m = new Marca
                {
                    NomeMarca = marca.NomeMarca
                };

                int id = _repo.Insert(m);

                return id;

            }
            catch
            {
                throw;
            }

            return 0;
        }

        public void Update(MarcaDTO marca)
        {
            try
            {
                if (GetById(marca.ID) != null)
                {
                    Marca m = new Marca
                    {
                        ID = marca.ID,
                        NomeMarca = marca.NomeMarca
                    };

                    _repo.Update(m);
                }
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repo.Delete(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
