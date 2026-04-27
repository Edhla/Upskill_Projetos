using WebAPI_3.DTOs;

namespace WebAPI_3.Services
{
    public interface IProductService
    {
        List<ProductDTO> GetAll();

        ProductDTO GetById(int id);

        int Create(ProductCreateDTO dto);

        void Update(int id, ProductCreateDTO dto);

        void Delete(int id);
    }
}
