namespace MyBeloved.API.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public ICollection<Notebook>? Notebooks { get; set; } = new List<Notebook>();
}