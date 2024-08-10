using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.NotebooksServices
{
    public class NotebookService : INotebookService
    {
        public Task<Response<Notebook>> CreateNotebook(NotebookDTO newNotebooks)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Notebook>>> DeleteNotebookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Notebook>>> GetAllNotebooks()
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Notebook>>> GetAllUserNotebooks(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Notebook>> GetNotebookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
