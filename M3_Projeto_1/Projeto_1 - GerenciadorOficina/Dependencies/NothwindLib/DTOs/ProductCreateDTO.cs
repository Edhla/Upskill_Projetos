namespace NothwindLib.DTOs
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
