using Microsoft.Data.SqlClient;
using NothwindLib.Models;

namespace NothwindLib.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll(string tagRepo);

        Product GetById(int id);

        int Insert(Product product, SqlTransaction trans);

        void Update(Product product, SqlTransaction trans);

        void Delete(int id, SqlTransaction trans);
    }
}
