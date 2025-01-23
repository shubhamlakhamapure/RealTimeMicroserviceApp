using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;
using ShoppingCart.UI.DTO;

namespace Product.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _dbContext;

        public CategoryService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryDTO> CreateUpdateCategory(CategoryDTO dto)
        {
            var category = ModelConverter.CategoryDto_To_CategoryModel(dto);

            if (category.iCategory > 0)
            {
                _dbContext.Categories.Update(category);
            }
            else
            {
                await _dbContext.Categories.AddAsync(category);
            }

            await _dbContext.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(id);
                if (category == null)
                {
                    return false;
                }
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await _dbContext.Categories.Select(p => ModelConverter.CategoryModel_To_CategoryDto(p)).
                            ToListAsync();

            return categories;
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _dbContext.Categories.
                 Where(x => x.iCategory == id).
                 FirstOrDefaultAsync();

           return  category is not null ? ModelConverter.CategoryModel_To_CategoryDto(category) : null;


        }

    }
}
