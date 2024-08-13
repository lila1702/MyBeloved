using MyBeloved.API.Models;

namespace MyBeloved.API.DTOs
{
    public class NotebookDTO
    {
        public int Id { get; set; }
        public int MadeById { get; set; }
        public List<Category> Categories { get; set; }
    }
}
