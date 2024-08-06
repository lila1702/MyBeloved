namespace MyBeloved.API.Models
{
    public class NotebookCategoryModel
    {
        public int NotebookId { get; set; }
        public Notebook Notebook { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
