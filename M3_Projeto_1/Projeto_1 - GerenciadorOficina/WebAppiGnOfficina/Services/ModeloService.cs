using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;
using Microsoft.Data.SqlClient;
using System.Reflection;

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
        public List<ModeloDTO> GetAll()
        {
            return _repo.GetAll()
                .Select(modelo => new ModeloDTO
                {
                    ID = modelo.ID,
                    NomeModelo = modelo.NomeModelo
                }).ToList();
        }
        public ModeloDTO GetById(int id)
        {
            var m = _repo.GetById(id);

            if (m == null)
            {
                return null;
            }

            return new ModeloDTO
            {
                ID = m.ID,
                NomeModelo = m.NomeModelo,
            };

        }

        public int Insert(ModeloDTO dto)
        {
            try
            {
                Modelo m = new Modelo
                {
                    NomeModelo = dto.NomeModelo
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

        public void Update(ModeloDTO dto)
        {
            try
            {
                Modelo m = new Modelo
                {
                    ID = dto.ID,
                    NomeModelo = dto.NomeModelo
                };
                _repo.Update(m);
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
