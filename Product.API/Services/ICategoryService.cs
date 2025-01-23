using Product.API.DTO;
using ShoppingCart.UI.DTO;

namespace Product.API.Services
{
    public interface ICategoryService
    {

        public Task<IEnumerable<CategoryDTO>> GetAllCategories();

        public Task<CategoryDTO> GetCategoryById(int id);
        public Task<bool> DeleteCategoryById(int id);
        public Task<CategoryDTO> CreateUpdateCategory(CategoryDTO dto);
    }
}
