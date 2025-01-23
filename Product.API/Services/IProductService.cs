using Product.API.DTO;

namespace Product.API.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProducts();

        public Task<ProductDTO> GetProductById(int id);
        public Task<bool> DeleteProductById(int id);
        public Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
    }
}
