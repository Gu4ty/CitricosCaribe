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
    public class TipoDireccionFrigorificoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoDireccionFrigorificoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoDireccionFrigorifico
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TipoDireccionFrigorificos.Include(t => t.Direccion).Include(t => t.Frigorifico);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TipoDireccionFrigorifico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionFrigorifico = await _context.TipoDireccionFrigorificos
                .Include(t => t.Direccion)
                .Include(t => t.Frigorifico)
                .FirstOrDefaultAsync(m => m.FrigorificoID == id);
            if (tipoDireccionFrigorifico == null)
            {
                return NotFound();
            }

            return View(tipoDireccionFrigorifico);
        }

        // GET: TipoDireccionFrigorifico/Create
        public IActionResult Create()
        {
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID");
            ViewData["FrigorificoID"] = new SelectList(_context.Frigorificos, "ID", "ID");
            return View();
        }

        // POST: TipoDireccionFrigorifico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrigorificoID,DireccionID")] TipoDireccionFrigorifico tipoDireccionFrigorifico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDireccionFrigorifico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionFrigorifico.DireccionID);
            ViewData["FrigorificoID"] = new SelectList(_context.Frigorificos, "ID", "ID", tipoDireccionFrigorifico.FrigorificoID);
            return View(tipoDireccionFrigorifico);
        }

        // GET: TipoDireccionFrigorifico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionFrigorifico = await _context.TipoDireccionFrigorificos.FindAsync(id);
            if (tipoDireccionFrigorifico == null)
            {
                return NotFound();
            }
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionFrigorifico.DireccionID);
            ViewData["FrigorificoID"] = new SelectList(_context.Frigorificos, "ID", "ID", tipoDireccionFrigorifico.FrigorificoID);
            return View(tipoDireccionFrigorifico);
        }

        // POST: TipoDireccionFrigorifico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrigorificoID,DireccionID")] TipoDireccionFrigorifico tipoDireccionFrigorifico)
        {
            if (id != tipoDireccionFrigorifico.FrigorificoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDireccionFrigorifico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDireccionFrigorificoExists(tipoDireccionFrigorifico.FrigorificoID))
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
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionFrigorifico.DireccionID);
            ViewData["FrigorificoID"] = new SelectList(_context.Frigorificos, "ID", "ID", tipoDireccionFrigorifico.FrigorificoID);
            return View(tipoDireccionFrigorifico);
        }

        // GET: TipoDireccionFrigorifico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionFrigorifico = await _context.TipoDireccionFrigorificos
                .Include(t => t.Direccion)
                .Include(t => t.Frigorifico)
                .FirstOrDefaultAsync(m => m.FrigorificoID == id);
            if (tipoDireccionFrigorifico == null)
            {
                return NotFound();
            }

            return View(tipoDireccionFrigorifico);
        }

        // POST: TipoDireccionFrigorifico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDireccionFrigorifico = await _context.TipoDireccionFrigorificos.FindAsync(id);
            _context.TipoDireccionFrigorificos.Remove(tipoDireccionFrigorifico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDireccionFrigorificoExists(int id)
        {
            return _context.TipoDireccionFrigorificos.Any(e => e.FrigorificoID == id);
        }
    }
}
