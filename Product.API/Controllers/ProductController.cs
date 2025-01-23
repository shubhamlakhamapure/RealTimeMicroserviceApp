using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.DTO;
using Product.API.Services;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private ResponseDTO _responseDTO = new();

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            _responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = string.Empty,
                Result = products.ToList()

            };
            if (products is null)
            {


                return NotFound(_responseDTO);
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productService.GetProductById(id);

            if (products is null)
            {

                return NotFound(_responseDTO);
            }

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = products;
            _responseDTO.Errors = new List<string>();
            _responseDTO.Message = "success";
            return Ok(_responseDTO);
        }


        [HttpDelete("{id:int}", Name = "DeleteProductById")]
        public async Task<IActionResult> DeleteProductById( int id)
        {
            bool result = await _productService.DeleteProductById(id);

            if (result)
            {
                return NotFound(_responseDTO = new ResponseDTO()
                {
                    Errors = new List<string>(),
                    IsSuccess = false,
                    Message = "failed",
                    Result = null

                });
            }

            return Ok(_responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = "success",
                Result = new Object()

            });
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            var productDto = await _productService.CreateUpdateProduct(productDTO);

            if (productDto is null)
            {
                return Unauthorized(_responseDTO = new ResponseDTO()
                {
                    Errors = new List<string>(),
                    IsSuccess = false,
                    Message = "failed",
                    Result = null

                });

            }
            return Ok(_responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = "sucess",
                Result = productDto

            });

        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            var productDto = await _productService.CreateUpdateProduct(productDTO);

            if (productDto is null)
            {
                return Unauthorized(_responseDTO = new ResponseDTO()
                {
                    Errors = new List<string>(),
                    IsSuccess = false,
                    Message = "failed",
                    Result = null

                });

            }
            return Ok(_responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = "sucess",
                Result = productDto

            });

        }
    }
}
