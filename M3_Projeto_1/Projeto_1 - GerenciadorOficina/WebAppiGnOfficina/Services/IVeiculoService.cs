using LibGerenciadorOficina.Models;

namespace WebAppiGnOfficina.Services
{
    public interface IVeiculoService
    {
        List<Veiculo> GetAll();
        Veiculo GetById(int id);

        int Insert(Veiculo veiculo);

        void Update(Veiculo veiculo);

        void Delete(int id);
    }
}
