using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManagement.Data;
using FlightManagement.DataModel;

namespace FLightApplication.Controllers
{
    public class TIcketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TIcketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TIckets
        public async Task<IActionResult> Index()
        {
              return _context.TIcket != null ? 
                          View(await _context.TIcket.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TIcket'  is null.");
        }

        // GET: TIckets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TIcket == null)
            {
                return NotFound();
            }

            var tIcket = await _context.TIcket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tIcket == null)
            {
                return NotFound();
            }

            return View(tIcket);
        }

        // GET: TIckets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TIckets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Price,FlightId,Id")] TIcket tIcket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIcket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIcket);
        }

        // GET: TIckets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TIcket == null)
            {
                return NotFound();
            }

            var tIcket = await _context.TIcket.FindAsync(id);
            if (tIcket == null)
            {
                return NotFound();
            }
            return View(tIcket);
        }

        // POST: TIckets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type,Price,FlightId,Id")] TIcket tIcket)
        {
            if (id != tIcket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIcket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIcketExists(tIcket.Id))
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
            return View(tIcket);
        }

        // GET: TIckets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TIcket == null)
            {
                return NotFound();
            }

            var tIcket = await _context.TIcket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tIcket == null)
            {
                return NotFound();
            }

            return View(tIcket);
        }

        // POST: TIckets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TIcket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TIcket'  is null.");
            }
            var tIcket = await _context.TIcket.FindAsync(id);
            if (tIcket != null)
            {
                _context.TIcket.Remove(tIcket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TIcketExists(int id)
        {
          return (_context.TIcket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
