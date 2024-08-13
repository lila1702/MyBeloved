using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.NotebooksServices
{
    public interface INotebookService
    {
        public Task<Response<Notebook>> CreateNotebook(int madeById);
        public Task<Response<List<Notebook>>> DeleteNotebookById(int id);
        public Task<Response<Notebook>> GetNotebookById(int id);
        public Task<Response<List<Notebook>>> GetAllUserNotebooks(int accountId);
        public Task<Response<List<Notebook>>> GetAllNotebooks();
        public Task<Response<Notebook>> AddCategoryToNotebook(int notebookId, int categoryId);
        //public Task<Response<Notebook>> UpdateNotebook(int id);
    }
}
