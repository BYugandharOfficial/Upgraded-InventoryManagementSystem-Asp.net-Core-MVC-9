using System.ComponentModel.DataAnnotations;

namespace InevntoryManagementSystem.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Products>? Products { get; set; }
        
    }
}
