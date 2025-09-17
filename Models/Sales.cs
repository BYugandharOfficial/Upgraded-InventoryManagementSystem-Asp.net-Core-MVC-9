using System.ComponentModel.DataAnnotations;

namespace InevntoryManagementSystem.Models
{
    public class Sales
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public Customers ?Customers { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Status { get; set; } // Paid, Unpaid, Partial

        public string? SoldBy { get; set; }
    }

}
