namespace MyBeloved.API.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

     // Many-to-Many Relationship Join Table
    public ICollection<NotebookCategory> NotebookCategories { get; set; } = new List<NotebookCategory>();
}