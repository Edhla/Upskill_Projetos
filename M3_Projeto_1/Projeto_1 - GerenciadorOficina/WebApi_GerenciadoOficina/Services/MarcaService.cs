using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;
using Microsoft.Data.SqlClient;

namespace WebApi_GerenciadoOficina.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repo;
        public MarcaService(IMarcaRepository repo)
        {
            _repo = repo;
            //_repo = new MarcaRepository("DB_GerenciadorOficinaTeste");

        }
        public List<Marca> GetAll()
        {
            //_repo("DB_GerenciadorOficinaTeste");

            List<Marca> marcas = new List<Marca>();

            return marcas;
        }
        public Marca GetById(int id)
        {
            Marca marca = null;

            return marca;

        }

        public int Insert(Marca marca, SqlTransaction trans)
        {
            return 0;
        }

        public void Update(Marca marca, SqlTransaction trans)
        {

        }

        public void Delete(int id, SqlTransaction trans)
        {

        }
    }
}
