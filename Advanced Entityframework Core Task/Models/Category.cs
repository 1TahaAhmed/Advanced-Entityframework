using System.ComponentModel.DataAnnotations;

namespace Advanced_Entityframework_Core_Task.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Electronics { get; set; } = string.Empty;
        public string furniture { get; set; } = string.Empty;
    }
}
