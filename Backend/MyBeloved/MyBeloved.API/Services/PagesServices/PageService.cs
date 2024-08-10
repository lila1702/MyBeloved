using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.PagesServices
{
    public class PageService : IPageService
    {
        public Task<Response<Page>> CreatePage(PageDTO newPage)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Page>>> DeletePageById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Page>>> GetAllPages()
        {
            throw new NotImplementedException();
        }
    }
}
