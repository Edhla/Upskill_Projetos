using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IModeloService
    {
        List<Modelo> GetAll();
        Modelo GetById(int id);

        int Insert(Modelo modelo);

        void Update(Modelo modelo);

        void Delete(int id);

    }
}
