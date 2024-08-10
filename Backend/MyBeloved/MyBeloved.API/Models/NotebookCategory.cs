using System.ComponentModel.DataAnnotations.Schema;

namespace MyBeloved.API.Models
{
    public class NotebookCategory
    {
        public int NotebookId { get; set; }
        [ForeignKey("NotebookId")]
        public Notebook Notebook { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
