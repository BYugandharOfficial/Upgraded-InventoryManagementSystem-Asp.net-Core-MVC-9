using InevntoryManagementSystem.Models;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static InevntoryManagementSystem.Controllers.ReportToPDFController;
using iText.Html2pdf;



namespace InevntoryManagementSystem.Controllers
{
    public class ReportToPDFController : Controller
    {
        private readonly AppDbContext _context;

        public ReportToPDFController(AppDbContext context)
        {
            _context = context;

        }

        // GET: ReportToPDF
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportToPDF.ToListAsync());
        }

        // GET: ReportToPDF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportToPDF = await _context.ReportToPDF
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (reportToPDF == null)
            {
                return NotFound();
            }

            return View(reportToPDF);
        }

        // GET: ReportToPDF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportToPDF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,InvoiceDate,CustomerId,FullName,CategoryName,ProductName,TotalAmount,PaidAmount,Status")] ReportToPDF reportToPDF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportToPDF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportToPDF);
        }

        // GET: ReportToPDF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportToPDF = await _context.ReportToPDF.FindAsync(id);
            if (reportToPDF == null)
            {
                return NotFound();
            }
            return View(reportToPDF);
        }

        // POST: ReportToPDF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,InvoiceDate,CustomerId,FullName,CategoryName,ProductName,TotalAmount,PaidAmount,Status")] ReportToPDF reportToPDF)
        {
            if (id != reportToPDF.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportToPDF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportToPDFExists(reportToPDF.InvoiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reportToPDF);
        }

        // GET: ReportToPDF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportToPDF = await _context.ReportToPDF
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (reportToPDF == null)
            {
                return NotFound();
            }

            return View(reportToPDF);
        }

        // POST: ReportToPDF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportToPDF = await _context.ReportToPDF.FindAsync(id);
            if (reportToPDF != null)
            {
                _context.ReportToPDF.Remove(reportToPDF);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportToPDFExists(int id)
        {
            return _context.ReportToPDF.Any(e => e.InvoiceId == id);
        }







        
    

        public IActionResult ViewToPDF()
        {
            var reportToPDF = _context.ReportToPDF.ToList(); // fetch from DB

            using (var ms = new MemoryStream())
            {
                using (var writer = new PdfWriter(ms))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // Title
                        document.Add(new Paragraph("Customers")
                            .SetFontSize(18));

                        // Table
                        var table = new Table(8, false); // 8 columns

                        table.AddHeaderCell("InvoiceDate");
                        table.AddHeaderCell("CustomerId");
                        table.AddHeaderCell("FullName");
                        table.AddHeaderCell("CategoryName");
                        table.AddHeaderCell("ProductName");
                        table.AddHeaderCell("TotalAmount");
                        table.AddHeaderCell("PaidAmount");
                        table.AddHeaderCell("Status");

                        foreach (var s in reportToPDF)
                        {
                            table.AddCell(s.InvoiceDate.ToString("yyyy-MM-dd"));
                            table.AddCell(s.CustomerId.ToString());
                            table.AddCell(s.FullName ?? string.Empty);
                            table.AddCell(s.CategoryName ?? string.Empty);
                            table.AddCell(s.ProductName ?? string.Empty);
                            table.AddCell(s.TotalAmount.ToString("F2"));
                            table.AddCell(s.PaidAmount.ToString("F2"));
                            table.AddCell(s.Status ?? string.Empty);
                        }

                        document.Add(table);
                        document.Close();
                    }
                }

                return File(ms.ToArray(), "application/pdf", "CustomerReport.pdf");
            }
        }
    }




}
                    























