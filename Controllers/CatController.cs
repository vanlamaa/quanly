using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirtswebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class CatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cat
        public async Task<IActionResult> Index()
        {
              return _context.Cat != null ? 
                          View(await _context.Cat.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cat'  is null.");
        }

        // GET: Cat/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatID,CatCategory,AnimalID,AnimalName,AnimalWeight,AnimalHeight")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: Cat/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CatID,CatCategory,AnimalID,AnimalName,AnimalWeight,AnimalHeight")] Cat cat)
        {
            if (id != cat.AnimalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.AnimalID))
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
            return View(cat);
        }

        // GET: Cat/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cat'  is null.");
            }
            var cat = await _context.Cat.FindAsync(id);
            if (cat != null)
            {
                _context.Cat.Remove(cat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(string id)
        {
          return (_context.Cat?.Any(e => e.AnimalID == id)).GetValueOrDefault();
        }
    }
}