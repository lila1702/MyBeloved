using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.NotebooksServices
{
    public interface INotebookService
    {
        public Task<Response<Notebook>> CreateNotebook(NotebookDTO newNotebooks);
        public Task<Response<List<Notebook>>> DeleteNotebookById(int id);
        public Task<Response<Notebook>> GetNotebookById(int id);
        public Task<Response<List<Notebook>>> GetAllUserNotebooks(int accountId);
        public Task<Response<List<Notebook>>> GetAllNotebooks();
    }
}
