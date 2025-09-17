using System.ComponentModel.DataAnnotations;

namespace InevntoryManagementSystem.Models
{
    public class Stocks
    {
        [Key]
        public int StockId { get; set; }

        
        public int ProductId { get; set; }

        public string? ProductName { get; set; }
        public Products ?Products { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int ReorderLevel { get; set; }

        public int StockMovements { get; set; }
        public int SupplierId { get; set; }
        public Suppliers ?Suppliers { get; set; }

    }

}
