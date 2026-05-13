using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IMarcaService
    {
        List<MarcaDTO> GetAll();
        MarcaDTO GetById(int id);

        int Insert(MarcaDTO marca);

        void Update(MarcaDTO marca);

        void Delete(int id);
    }
}
