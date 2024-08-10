using MyBeloved.API.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyBeloved.API.DTOs
{
    public class NotebookDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public int MadeById { get; set; }
        public List<Category> Categories { get; set; }
    }
}
