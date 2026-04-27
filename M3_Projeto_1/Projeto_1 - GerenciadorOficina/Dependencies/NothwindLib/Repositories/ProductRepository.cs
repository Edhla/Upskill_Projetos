using LibDB;
using Microsoft.Data.SqlClient;
using NothwindLib.Models;
using NothwindLib.Repositories;


namespace NothwindLib.Repositories
{
    public class ProductRepository : IProductRepository
    {
        internal string ConectionString = "";
        public List<Product> GetAll(string tagRepo = "NorthwindTest")
        { 
            ConectionString = Conection2Repo.GetRepoConection(tagRepo);
            DALPro.ConnectionString = ConectionString;
            string sql = "SELECT * FROM Products";

            return DALPro.Query<Product>(sql);
        }

        public Product GetById(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductID=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            return DALPro.Query<Product>(sql, param).FirstOrDefault();
        }

        public int Insert(Product p, SqlTransaction trans)
        {
            string sql = @"INSERT INTO Products
                       (ProductName, SupplierID, CategoryID, UnitPrice, Discontinued)
                       VALUES
                       (@ProductName, @SupplierID, @CategoryID, @UnitPrice, 0);

                       SELECT SCOPE_IDENTITY();";

            var param = new Dictionary<string, object>
        {
            {"@ProductName", p.ProductName},
            {"@SupplierID", p.SupplierID},
            {"@CategoryID", p.CategoryID},
            {"@UnitPrice", p.UnitPrice}
        };

            return Convert.ToInt32(DALPro.ExecuteScalar(sql, param, trans));
        }

        public void Update(Product p, SqlTransaction trans)
        {
            string sql = @"UPDATE Products
                       SET ProductName=@ProductName,
                           UnitPrice=@UnitPrice
                       WHERE ProductID=@ProductID";

            var param = new Dictionary<string, object>
        {
            {"@ProductID", p.ProductID},
            {"@ProductName", p.ProductName},
            {"@UnitPrice", p.UnitPrice}
        };

            DALPro.Execute(sql, param, trans);
        }

        public void Delete(int id, SqlTransaction trans)
        {
            string sql = "DELETE FROM Products WHERE ProductID=@id";

            var param = new Dictionary<string, object>
        {
            {"@id", id}
        };

            DALPro.Execute(sql, param, trans);
        }
    }
}
