using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DU_AN_GROUP113_NET105.Models.Data;
using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace DU_AN_GROUP113_NET105.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ProjectContext _context;

        public ProductsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Product.Include(p => p.Brand).Include(p => p.ProductCategory).Include(p => p.Size).Include(p => p.Supplier);
            return View(await projectContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.ProductCategory)
                .Include(p => p.Size)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Name");
            ViewData["SizeCategory"] = new SelectList(_context.Set<Size>(), "Name", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Address");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Image,Price,PromotionPrice,Status,Details,SizeCategory,BrandId,ProductCategoryId,SupplierId")] Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await image.CopyToAsync(memoryStream);
                        product.Image = memoryStream.ToArray();
                    }
                }
                product.Id = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewData["SizeCategory"] = new SelectList(_context.Set<Size>(), "Name", "Name", product.SizeCategory);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Address", product.SupplierId);
            return View(product);
        }

        public async Task<IActionResult> GetImage(Guid id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null || product.Image == null)
            {
                return NotFound();
            }

            return File(product.Image, "image/jpeg");
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewData["SizeCategory"] = new SelectList(_context.Set<Size>(), "Name", "Name", product.SizeCategory);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Address", product.SupplierId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Quantity,Image,Price,PromotionPrice,Status,Details,SizeCategory,BrandId,ProductCategoryId,SupplierId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Name", product.ProductCategoryId);
            ViewData["SizeCategory"] = new SelectList(_context.Set<Size>(), "Name", "Name", product.SizeCategory);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Address", product.SupplierId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.ProductCategory)
                .Include(p => p.Size)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

    }
}
