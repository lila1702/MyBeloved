using Microsoft.AspNetCore.Mvc;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;
using MyBeloved.API.Services.PagesServices;

namespace MyBeloved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        public readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpPost("CreatePage")]
        public async Task<ActionResult<Response<Page>>> CreatePage(PageDTO newPage)
        {
            return Ok(await _pageService.CreatePage(newPage));
        }

        [HttpDelete("DeletePageById/{id}")]
        public async Task<ActionResult<Response<List<Page>>>> DeletePageById(int id)
        {
            return Ok(await _pageService.DeletePageById(id)); 
        }

        [HttpGet("GetPages")]
        public async Task<ActionResult<Response<List<Page>>>> GetAllPages()
        {
            return Ok(await _pageService.GetAllPages());
        }
    }
}
