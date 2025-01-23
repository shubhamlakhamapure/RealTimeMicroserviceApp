using Product.API.DTO;

namespace ShoppingCart.UI.Services.Implementation
{
    public class ProductService : IProductService
    {
        public Task<T> CreateUpdateProduct<T>(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllProducts<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetProductById<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
