using System.ComponentModel.DataAnnotations;

namespace InevntoryManagementSystem.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }


}
