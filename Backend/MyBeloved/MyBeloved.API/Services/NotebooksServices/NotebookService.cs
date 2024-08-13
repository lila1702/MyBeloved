using Microsoft.EntityFrameworkCore;
using MyBeloved.API.DataContext;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.NotebooksServices
{
    public class NotebookService : INotebookService
    {
        private readonly ApplicationDbContext _context;

        public NotebookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Notebook>> CreateNotebook(int madeById)
        {
            Response<Notebook> response = new Response<Notebook>();
            NotebookDTO newNotebook = new NotebookDTO
            {
                MadeById = madeById
            };

            try
            {
                if (newNotebook == null)
                {
                    response.Message = "Notebook is null";
                    response.Success = false;
                    return response;
                }

                Notebook notebook = new Notebook
                {
                    MadeById = newNotebook.MadeById,
                    MadeBy = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == newNotebook.MadeById)
                };

                _context.Notebooks.Add(notebook);
                await _context.SaveChangesAsync();
                response.Data = notebook;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Notebook>>> DeleteNotebookById(int id)
        {
            Response<List<Notebook>> response = new Response<List<Notebook>>();

            try
            {
                Notebook notebook = await _context.Notebooks.FirstOrDefaultAsync(n => n.Id == id);

                if (notebook == null)
                {
                    response.Message = "Notebook not found";
                    response.Success = false;
                    return response;
                }

                _context.Notebooks.Remove(notebook);
                await _context.SaveChangesAsync();

                response.Data = await _context.Notebooks
                    .Include(n => n.MadeBy)
                    .Include(n => n.Categories.OrderBy(c => c.Id))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Notebook>>> GetAllNotebooks()
        {
            Response<List<Notebook>> response = new Response<List<Notebook>>();

            try
            {
                response.Data = await _context.Notebooks
                    .Include(n => n.MadeBy)
                    .Include(n => n.Categories.OrderBy(c => c.Id))
                    .OrderBy(n => n.Id)
                    .ToListAsync();

                if (response.Data.Count == 0)
                {
                    response.Message = "No notebooks found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Notebook>>> GetAllUserNotebooks(int accountId)
        {
            Response<List<Notebook>> response = new Response<List<Notebook>>();

            try
            {
                response.Data = await _context.Notebooks
                    .Where(n => n.MadeById == accountId)
                    .Include(n => n.MadeBy)
                    .Include(n => n.Categories.OrderBy(c => c.Id))
                    .OrderBy(n => n.Id)
                    .ToListAsync();

                if (response.Data.Count() == 0)
                {
                    response.Message = "No notebooks found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Notebook>> GetNotebookById(int id)
        {
            Response<Notebook> response = new Response<Notebook>();

            try
            {
                Notebook notebook = await _context.Notebooks
                    .Include(n => n.MadeBy)
                    .Include(n => n.Categories.OrderBy(c => c.Id))
                    .FirstOrDefaultAsync(n => n.Id == id);

                if (notebook == null)
                {
                    response.Message = "Notebook not found";
                    response.Success = false;
                    return response;
                }

                response.Data = notebook;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Notebook>> AddCategoryToNotebook(int notebookId, int categoryId)
        {
            Response<Notebook> response = new Response<Notebook>();

            try
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
                Notebook notebook = await _context.Notebooks.FirstOrDefaultAsync(n => n.Id == notebookId);

                if (notebook == null || category == null)
                {
                    response.Message = "Notebook or category not found";
                    response.Success = false;
                    return response;
                }

                notebook.Categories.Add(category);
                _context.Notebooks.Update(notebook);
                await _context.SaveChangesAsync();
                response.Data = notebook;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Notebook>> RemoveCategoryFromNotebookById(int notebookId, int categoryId)
        {
            Response<Notebook> response = new Response<Notebook>();

            try
            {
                Notebook notebook = await _context.Notebooks.Include(n => n.Categories)
                    .Where(n => n.Categories.Any(c => c.Id == categoryId)).FirstOrDefaultAsync(n => n.Id == notebookId);

                if (notebook == null)
                {
                    response.Message = "Category not found in this notebook";
                    response.Success = false;
                    return response;
                }

                notebook.Categories.Remove(notebook.Categories.FirstOrDefault(c => c.Id == categoryId));
                _context.Notebooks.Update(notebook);
                await _context.SaveChangesAsync();
                response.Data = notebook;
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
