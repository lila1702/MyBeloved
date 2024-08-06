namespace MyBeloved.API.Models;

public class Notebook
{
    public int Id { get; set; }
    public Account MadeBy { get; set; }

    public ICollection<Category> Category { get; set; } = new List<Category>();
    public ICollection<Page>? Pages { get; set; } = new List<Page>();
}