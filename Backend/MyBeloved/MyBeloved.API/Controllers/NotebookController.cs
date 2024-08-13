using Microsoft.AspNetCore.Mvc;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;
using MyBeloved.API.Services.NotebooksServices;

namespace MyBeloved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebookController : ControllerBase
    {
        public readonly INotebookService _notebookService;

        public NotebookController(INotebookService notebookService)
        {
            _notebookService = notebookService;
        }

        [HttpPost("CreateNotebook")]
        public async Task<ActionResult<Response<Notebook>>> CreateNotebook(int madeById)
        {
            return Ok(await _notebookService.CreateNotebook(madeById));
        }

        [HttpDelete("DeleteNotebookById/{id}")]
        public async Task<ActionResult<Response<List<Notebook>>>> DeleteNotebookById(int id)
        {
            return Ok(await _notebookService.DeleteNotebookById(id));
        }

        [HttpGet("GetNotebook/{id}")]
        public async Task<ActionResult<Response<Notebook>>> GetNotebookById(int id)
        {
            return Ok(await _notebookService.GetNotebookById(id));
        }

        [HttpGet("GetNotebooks/{accountId}")]
        public async Task<ActionResult<Response<List<Notebook>>>> GetNotebooksByAccountId(int accountId)
        {
            return Ok(await _notebookService.GetAllUserNotebooks(accountId));
        }

        [HttpGet("GetNotebooks")]
        public async Task<ActionResult<Response<List<Notebook>>>> GetNotebooks()
        {
            return Ok(await _notebookService.GetAllNotebooks());
        }

        [HttpPatch("AddCategoryToNotebook")]
        public async Task<ActionResult<Response<Notebook>>> AddCategoryToNotebook(int notebookId, int categoryId)
        {
            return Ok(await _notebookService.AddCategoryToNotebook(notebookId, categoryId));
        }

        [HttpPatch("RemoveCategoryFromNotebook")]
        public async Task<ActionResult<Response<Notebook>>> RemoveCategoryFromNotebook(int notebookId, int categoryId)
        {
            return Ok(await _notebookService.RemoveCategoryFromNotebookById(notebookId, categoryId));
        }
    }
}
