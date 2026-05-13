using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IVeiculoService
    {
        List<VeiculoDTO> GetAll();
        VeiculoDTO GetById(int id);

        int Insert(VeiculoDTO veiculo);

        void Update(VeiculoDTO veiculo);

        void Delete(int id);
    }
}
