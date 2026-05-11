using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IMarcaService
    {
        List<MarcaDTO> GetAll();
        Marca GetById(int id);

        int Insert(Marca marca);

        void Update(Marca marca);

        void Delete(int id);
    }
}
