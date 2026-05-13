using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;
using Microsoft.Data.SqlClient;

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
        public List<VeiculoDTO> GetAll()
        {
            return _repo.GetAll()
                .Select(veiculo => new VeiculoDTO
                {
                    Id = veiculo.Id,
                    Ano = veiculo.Ano,
                    Estado = veiculo.Estado,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    UltimaInspecao = veiculo.UltimaInspecao,
                }).ToList();
        }
        public VeiculoDTO GetById(int id)
        {
            var v = _repo.GetById(id);

            if (v == null)
            {
                return null;
            }

            return new VeiculoDTO
            {
                Id = v.Id,
                Ano = v.Ano,
                Estado = v.Estado,
                Marca = v.Marca,
                Modelo = v.Modelo,
                UltimaInspecao = v.UltimaInspecao,
            };
        }

        public int Insert(VeiculoDTO veiculo)
        {
            try
            {
                Veiculo m = new Veiculo
                {
                    Id = veiculo.Id,
                    Ano = veiculo.Ano,
                    Estado = veiculo.Estado,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    UltimaInspecao = veiculo.UltimaInspecao,
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

        public void Update(VeiculoDTO veiculo)
        {
            try
            {
                Veiculo m = new Veiculo
                {
                    Id = veiculo.Id,
                    Ano = veiculo.Ano,
                    Estado = veiculo.Estado,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    UltimaInspecao = veiculo.UltimaInspecao,
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
