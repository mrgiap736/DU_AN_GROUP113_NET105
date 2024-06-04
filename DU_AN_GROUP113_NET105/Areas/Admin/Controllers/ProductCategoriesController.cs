﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DU_AN_GROUP113_NET105.Models.Data;
using DU_AN_GROUP113_NET105.Models.Entities;

namespace DU_AN_GROUP113_NET105.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoriesController : Controller
    {
        private readonly ProjectContext _context;

        public ProductCategoriesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategory.ToListAsync());
        }

        // GET: Admin/ProductCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Sort")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.Id = Guid.NewGuid();
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Status,Sort")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory != null)
            {
                _context.ProductCategory.Remove(productCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(Guid id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }
    }
}
