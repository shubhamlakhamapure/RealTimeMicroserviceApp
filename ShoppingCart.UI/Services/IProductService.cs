using Product.API.DTO;
using ShoppingCart.UI.DTO;

namespace ShoppingCart.UI.Services
{
    public interface IProductService
    {

         Task<T> GetAllProducts<T>();

         Task<T> GetProductById<T>(int id);
         Task<bool> DeleteProductById(int id);
         Task<T> CreateUpdateProduct<T>(ProductDTO productDTO);
    }
}
