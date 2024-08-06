using Microsoft.AspNetCore.Mvc;
using MyBeloved.API.DTOs.Categories;
using MyBeloved.API.Models;
using MyBeloved.API.Services.CategoriesServices;

namespace MyBeloved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Response<Category>>> CreateCategory(CategoryDTO newCategory)
        {
            return Ok(await _categoryService.CreateCategory(newCategory));
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<Response<Category>>> GetCategoryById(int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<Response<List<Category>>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult<Response<List<Category>>>> DeleteCategoryById(int id)
        {
            return Ok(await _categoryService.DeleteCategoryById(id));
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<ActionResult<Response<Category>>> UpdateCategoryById(CategoryEditDTO editedCategory)
        {
            return Ok(await _categoryService.UpdateCategoryById(editedCategory));
        }
    }
}
