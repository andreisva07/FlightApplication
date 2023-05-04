﻿using System;
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
    public class PassengersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassengersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
              return _context.Passenger != null ? 
                          View(await _context.Passenger.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Passenger'  is null.");
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerName,PassengerSurname,Email,Telephone,Id")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                passenger.Id = Guid.NewGuid();
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PassengerName,PassengerSurname,Email,Telephone,Id")] Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.Id))
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
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Passenger == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passenger'  is null.");
            }
            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger != null)
            {
                _context.Passenger.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(Guid id)
        {
          return (_context.Passenger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
