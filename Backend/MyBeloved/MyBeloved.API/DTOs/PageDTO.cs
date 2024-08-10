namespace MyBeloved.API.DTOs
{
    public class PageDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int NotebookId { get; set; }
        public int CategoryId { get; set; }
    }
}
