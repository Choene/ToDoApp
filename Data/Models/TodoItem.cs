using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        // Optional field for descriptions
        public string? TodoDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
