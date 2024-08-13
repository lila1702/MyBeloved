using System.ComponentModel.DataAnnotations.Schema;

namespace MyBeloved.API.Models;

public class Page
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int NotebookId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Properties
    public Category Category { get; set; }
    public Notebook Notebook { get; set; }
}