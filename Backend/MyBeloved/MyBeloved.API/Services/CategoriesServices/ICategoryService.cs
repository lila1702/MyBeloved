    using MyBeloved.API.DTOs;
    using MyBeloved.API.Models;

    namespace MyBeloved.API.Services.CategoriesServices
    {
        public interface ICategoryService
        {
            Task<Response<Category>> CreateCategory(CategoryDTO newCategory);
            Task<Response<Category>> UpdateCategoryById(CategoryDTO editedCategory);
            Task<Response<List<Category>>> DeleteCategoryById (int id);
            Task<Response<Category>> GetCategoryById (int id);
            Task<Response<List<Category>>> GetAllCategories();
        }
    }
