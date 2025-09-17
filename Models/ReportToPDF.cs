using System.ComponentModel.DataAnnotations;

namespace InevntoryManagementSystem.Models
{
    public class ReportToPDF
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Status { get; set; } 
    }
}
