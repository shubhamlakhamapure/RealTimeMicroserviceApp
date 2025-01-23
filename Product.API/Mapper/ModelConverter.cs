using Product.API.DTO;
using Product.API.Entities;
using ShoppingCart.UI.DTO;

namespace Product.API.Mapper
{
    public static class ModelConverter
    {

        #region Product
        public static Product.API.Entities.Product ProductDto_To_ProductModel(ProductDTO productDTO)
        {
            return new Entities.Product
            {
                iProduct = productDTO.iProduct,
                CategoryId = productDTO.CategoryId,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                Price = productDTO.Price,
                Title = productDTO.Title,
            };
        }

        public static ProductDTO ProductModel_To_ProductDto(Entities.Product product)
        {
            return new ProductDTO
            {
                iProduct = product.iProduct,
                CategoryId = product.CategoryId,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Title = product.Title,
            };
        }

        #endregion


        #region Category
        public static CategoryDTO CategoryModel_To_CategoryDto (Category category)
        {
            return new CategoryDTO
            {
               iCategory = category.iCategory,
               Title = category.Title,
            };
        }

        public static Category CategoryDto_To_CategoryModel(CategoryDTO dto)
        {
            return new Category
            {
                iCategory = dto.iCategory,
                Title = dto.Title,
            };
        }

        #endregion

    }
}
