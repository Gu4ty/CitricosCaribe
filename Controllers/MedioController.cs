using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitricosCaribe.Data;
using CitricosCaribe.Models;

namespace CitricosCaribe.Controllers
{
    public class MedioController : Controller
    {
        private readonly AppDbContext _context;

        public MedioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Medio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medios.ToListAsync());
        }

        // GET: Medio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medio = await _context.Medios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medio == null)
            {
                return NotFound();
            }

            return View(medio);
        }

        // GET: Medio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre")] Medio medio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medio);
        }

        // GET: Medio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medio = await _context.Medios.FindAsync(id);
            if (medio == null)
            {
                return NotFound();
            }
            return View(medio);
        }

        // POST: Medio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] Medio medio)
        {
            if (id != medio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedioExists(medio.ID))
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
            return View(medio);
        }

        // GET: Medio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medio = await _context.Medios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medio == null)
            {
                return NotFound();
            }

            return View(medio);
        }

        // POST: Medio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medio = await _context.Medios.FindAsync(id);
            _context.Medios.Remove(medio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedioExists(int id)
        {
            return _context.Medios.Any(e => e.ID == id);
        }
    }
}
