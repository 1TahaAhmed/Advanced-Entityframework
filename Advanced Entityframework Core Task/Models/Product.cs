using System.ComponentModel.DataAnnotations;

namespace Advanced_Entityframework_Core_Task.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] RowVersion { get; set; } = [];
    }
}