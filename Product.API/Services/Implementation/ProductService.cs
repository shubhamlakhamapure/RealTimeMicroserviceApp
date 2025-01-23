using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;
using Product.API.Services;

namespace Product.API.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            var product = ModelConverter.ProductDto_To_ProductModel(productDTO);

            if (product.iProduct > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                await _dbContext.Products.AddAsync(product);
            }

            await _dbContext.SaveChangesAsync();
            return productDTO;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                if (product is null)
                {
                    return false;
                }
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            try
            {
                var products = await _dbContext.Products.Select(p => ModelConverter.ProductModel_To_ProductDto(p)).
                           ToListAsync();

                return products;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            try
            {
                var product = await _dbContext.Products
                                .Where(p => p.iProduct == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                var productDto = product is not null ? ModelConverter.ProductModel_To_ProductDto(product) : null;

                return productDto;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}
