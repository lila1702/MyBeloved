using System.ComponentModel.DataAnnotations.Schema;

namespace MyBeloved.API.Models;

public class Notebook
{
    public int Id { get; set; }
    public int MadeById { get; set; }

    // Navigation Properties
    public Account MadeBy { get; set; }
    public ICollection<Page> Pages { get; set; } = new List<Page>();

    // Many-to-Many Relationship Join Table
    public ICollection<NotebookCategory> NotebookCategories { get; set; } = new List<NotebookCategory>();
}