using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InevntoryManagementSystem.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; } //Primary key

        [Required]
        public string? ProductName { get; set; }
       
        public string? CategoryName { get; set; }
        public int Quantity { get; set; }


        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string? Unit { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }
         
        public Categories? Categories { get; set; } // Navigation property
    }


}



