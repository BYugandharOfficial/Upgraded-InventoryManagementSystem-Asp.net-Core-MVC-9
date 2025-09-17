using InevntoryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InevntoryManagementSystem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly Models.AppDbContext _context;
        public DashboardController(Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            ViewBag.TotalProducts = _context.Products.Count();
            ViewBag.TotalCategories = _context.Categories.Count();
            ViewBag.TotalSuppliers = _context.Suppliers.Count();
            ViewBag.TotalCustomers = _context.Customers.Count();
            ViewBag.TotalSales = _context.Sales.Count();

           
            ViewBag.PresentStock = _context.Stocks.Sum(s => s.Quantity);

            
            var lowStocks = _context.Stocks
                .Where(s => s.Quantity <= s.ReorderLevel)
                .Include(s => s.Products)
                .ToList();

            
            return View(lowStocks);
        }
    }
}
