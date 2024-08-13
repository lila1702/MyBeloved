using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.PagesServices
{
    public interface IPageService
    {
        public Task<Response<Page>> CreatePage(PageDTO newPage);
        public Task<Response<List<Page>>> DeletePageById(int id);
        public Task<Response<List<Page>>> GetAllPages();
    }
}
