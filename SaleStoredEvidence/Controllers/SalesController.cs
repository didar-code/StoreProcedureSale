using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SaleStoredEvidence.Models;
using SaleStoredEvidence.Models.ViewModels;
using System;
using System.Data;

namespace SaleStoredEvidence.Controllers
{
    public class SalesController : Controller
    {
        private readonly SaleStoredDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SalesController(SaleStoredDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var sales = await _context.Sales
                .Include(s => s.Properties)
                .Include(s => s.PaymentMethod)
                .ToListAsync();

            return View(sales);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SalesViewModel
            {
                PaymentMethods = _context.PaymentMethods.ToList(),
                Properties = new List<PropertyViewModel>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PaymentMethods = _context.PaymentMethods.ToList();
                return View(model);
            }

            string imagePath = model.ProfileFile != null
                ? await SaveImage(model.ProfileFile)
                : "/images/noImg.jpg";

            var propertyTable = new DataTable();
            propertyTable.Columns.Add("PropertyType", typeof(string));
            propertyTable.Columns.Add("Location", typeof(string));

            if (model.Properties != null)
            {
                foreach (var p in model.Properties)
                {
                    if (!string.IsNullOrWhiteSpace(p.PropertyType) &&
                        !string.IsNullOrWhiteSpace(p.Location))
                    {
                        propertyTable.Rows.Add(p.PropertyType, p.Location);
                    }
                }
            }

            var parameters = new[]
            {
                new SqlParameter("@SaleDate", model.SaleDate),
                new SqlParameter("@TotalPrice", model.TotalPrice),
                new SqlParameter("@ClientName", model.ClientName ?? (object)DBNull.Value),
                new SqlParameter("@MobileNo", model.MobileNo ?? (object)DBNull.Value),
                new SqlParameter("@ClientImage", imagePath),
                new SqlParameter("@PaymentMethodId", model.PaymentMethodId),
                new SqlParameter("@IsPaid", model.IsPaid),
               
            };

            await _context.Database.ExecuteSqlRawAsync(
    "EXEC dbo.InsertSaleSP @SaleDate, @TotalPrice, @ClientName, @MobileNo, @ClientImage, @PaymentMethodId, @IsPaid",
    parameters
);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Properties)
                .FirstOrDefaultAsync(s => s.SalesId == id);

            if (sale == null) return NotFound();

            var model = new SalesViewModel
            {
                SalesId = sale.SalesId,
                SaleDate = sale.SaleDate,
                TotalPrice = sale.TotalPrice,
                ClientName = sale.ClientName,
                MobileNo = sale.MobileNo,
                PaymentMethodId = sale.PaymentMethodId,
                IsPaid = sale.IsPaid,
                ClientImage = sale.ClientImage,
                Properties = sale.Properties.Select(p => new PropertyViewModel
                {
                    PropertyId = p.PropertyId,
                    PropertyType = p.PropertyType,
                    Location = p.Location
                }).ToList(),
                PaymentMethods = _context.PaymentMethods.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SalesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PaymentMethods = _context.PaymentMethods.ToList();
                return View(model);
            }

            var sale = await _context.Sales.FindAsync(model.SalesId);
            if (sale == null) return NotFound();

            string imagePath = sale.ClientImage;

            if (model.ProfileFile != null)
            {
                imagePath = await SaveImage(model.ProfileFile);
            }

            var propertyTable = new DataTable();
            propertyTable.Columns.Add("PropertyType", typeof(string));
            propertyTable.Columns.Add("Location", typeof(string));

            if (model.Properties != null)
            {
                foreach (var p in model.Properties)
                {
                    if (!string.IsNullOrWhiteSpace(p.PropertyType) &&
                        !string.IsNullOrWhiteSpace(p.Location))
                    {
                        propertyTable.Rows.Add(p.PropertyType, p.Location);
                    }
                }
            }

            var parameters = new[]
            {
                new SqlParameter("@SalesId", model.SalesId),
                new SqlParameter("@SaleDate", model.SaleDate),
                new SqlParameter("@TotalPrice", model.TotalPrice),
                new SqlParameter("@ClientName", model.ClientName ?? (object)DBNull.Value),
                new SqlParameter("@MobileNo", model.MobileNo ?? (object)DBNull.Value),
                new SqlParameter("@ClientImage", imagePath),
                new SqlParameter("@PaymentMethodId", model.PaymentMethodId),
                new SqlParameter("@IsPaid", model.IsPaid),
                new SqlParameter("@Properties", SqlDbType.Structured)
                {
                    TypeName = "dbo.PropertyType",
                    Value = propertyTable
                }
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.UpdateSaleSP @SalesId, @SaleDate, @TotalPrice, @ClientName, @MobileNo, @ClientImage, @PaymentMethodId, @IsPaid, @Properties",
                parameters
            );

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var param = new SqlParameter("@SalesId", id);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.DeleteSaleSP @SalesId",
                param
            );

            return RedirectToAction("Index");
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_env.WebRootPath, "images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fullPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }
    }
}
