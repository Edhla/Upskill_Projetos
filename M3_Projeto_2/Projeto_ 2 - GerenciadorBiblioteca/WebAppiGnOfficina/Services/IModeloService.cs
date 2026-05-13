using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IModeloService
    {
        List<ModeloDTO> GetAll();
        ModeloDTO GetById(int id);

        int Insert(ModeloDTO modelo);

        void Update(ModeloDTO modelo);

        void Delete(int id);

    }
}
