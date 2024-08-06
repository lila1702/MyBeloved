namespace MyBeloved.API.Models;

public class Page
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int NotebookId { get; set; }
    public int CategoryId { get; set; }
    public Notebook Notebook { get; set; }
    public Category Category { get; set; }
}