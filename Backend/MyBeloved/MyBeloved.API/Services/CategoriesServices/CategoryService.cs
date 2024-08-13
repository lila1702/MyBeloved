using Microsoft.EntityFrameworkCore;
using MyBeloved.API.DataContext;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.CategoriesServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Category>> CreateCategory(CategoryDTO newCategory)
        {
            Response<Category> response = new Response<Category>();

            try
            {
                if (newCategory == null)
                {
                    response.Message = "Category is null";
                    response.Success = false;
                    return response;
                }

                Category category = new Category
                {
                    Title = newCategory.Title,
                    Description = newCategory.Description
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                response.Data = category;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Category>>> DeleteCategoryById(int id)
        {
            Response<List<Category>> response = new Response<List<Category>>();

            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    response.Message = "Category not found";
                    response.Success = false;
                    return response;
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                response.Data = _context.Categories.ToList();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Category>> GetCategoryById(int id)
        {
            Response<Category> response = new Response<Category>();

            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    response.Message = "Category not found";
                    response.Success = false;
                    return response;
                }

                response.Data = category;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Category>>> GetAllCategories()
        {
            Response<List<Category>> response = new Response<List<Category>>();

            try
            {
                response.Data = _context.Categories.ToList();

                if (response.Data.Count() == 0)
                {
                    response.Message = "No categories found";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Category>> UpdateCategoryById(CategoryDTO editedCategory)
        {
            Response<Category> response = new Response<Category>();

            try
            {
                Category category = _context.Categories.AsNoTracking().FirstOrDefault(a => a.Id == editedCategory.Id);

                if (editedCategory == null)
                {
                    response.Message = "Category not found";
                    response.Success = false;
                    return response;
                }

                category.Title = editedCategory.Title;
                category.Description = editedCategory.Description;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                response.Data = _context.Categories.FirstOrDefault(a => a.Id == editedCategory.Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
