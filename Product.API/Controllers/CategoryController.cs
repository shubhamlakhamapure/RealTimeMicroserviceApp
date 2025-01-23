using Microsoft.AspNetCore.Mvc;
using Product.API.DTO;
using Product.API.Services;
using ShoppingCart.UI.DTO;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private ResponseDTO _responseDTO = new();

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _categoryService.GetAllCategories();

            _responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = string.Empty,
                Result = categories.ToList()

            };
            if (categories is null)
            {


                return NotFound(_responseDTO);
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}",Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category is null)
            {
                _responseDTO = new ResponseDTO()
                {
                    Errors = new List<string>(),
                    IsSuccess = false,
                    Message = string.Empty,
                    Result = null,
                };

                return NotFound(_responseDTO);
            }

            _responseDTO = new ResponseDTO()
            {
                Errors = new List<string>(),
                IsSuccess = true,
                Message = string.Empty,
                Result = category
            };
           
            return Ok(_responseDTO);
        }


        [HttpDelete("{id:int}",Name = "DeleteCategoryById")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            bool result = await _categoryService.DeleteCategoryById(id);

            if (result)
            {
                return NotFound(result);
            }

            return Ok(result);
        }



        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            var categoryDto = await _categoryService.CreateUpdateCategory(categoryDTO);

            if (categoryDto is null)
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
                Message = "success",
                Result = categoryDto

            });

        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryDto = await _categoryService.CreateUpdateCategory(categoryDTO);

            if (categoryDto is null)
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
                Message = "success",
                Result = categoryDto

            });

        }
    }
}
