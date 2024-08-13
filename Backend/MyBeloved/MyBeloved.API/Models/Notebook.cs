using System.ComponentModel.DataAnnotations.Schema;

namespace MyBeloved.API.Models;

public class Notebook
{
    public int Id { get; set; }
    public int MadeById { get; set; }

    // Navigation Properties
    public Account MadeBy { get; set; }
    public List<Category> Categories { get; } = new List<Category>();
    public List<Page> Pages { get; } = new List<Page>();
}