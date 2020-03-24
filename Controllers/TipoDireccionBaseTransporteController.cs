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
    public class TipoDireccionBaseTransporteController : Controller
    {
        private readonly AppDbContext _context;

        public TipoDireccionBaseTransporteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoDireccionBaseTransporte
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TipoDireccionBaseTransportes.Include(t => t.BaseTransporte).Include(t => t.Direccion);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TipoDireccionBaseTransporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionBaseTransporte = await _context.TipoDireccionBaseTransportes
                .Include(t => t.BaseTransporte)
                .Include(t => t.Direccion)
                .FirstOrDefaultAsync(m => m.BaseTransporteID == id);
            if (tipoDireccionBaseTransporte == null)
            {
                return NotFound();
            }

            return View(tipoDireccionBaseTransporte);
        }

        // GET: TipoDireccionBaseTransporte/Create
        public IActionResult Create()
        {
            ViewData["BaseTransporteID"] = new SelectList(_context.BasesTransportes, "ID", "ID");
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID");
            return View();
        }

        // POST: TipoDireccionBaseTransporte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseTransporteID,DireccionID")] TipoDireccionBaseTransporte tipoDireccionBaseTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDireccionBaseTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseTransporteID"] = new SelectList(_context.BasesTransportes, "ID", "ID", tipoDireccionBaseTransporte.BaseTransporteID);
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionBaseTransporte.DireccionID);
            return View(tipoDireccionBaseTransporte);
        }

        // GET: TipoDireccionBaseTransporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionBaseTransporte = await _context.TipoDireccionBaseTransportes.FindAsync(id);
            if (tipoDireccionBaseTransporte == null)
            {
                return NotFound();
            }
            ViewData["BaseTransporteID"] = new SelectList(_context.BasesTransportes, "ID", "ID", tipoDireccionBaseTransporte.BaseTransporteID);
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionBaseTransporte.DireccionID);
            return View(tipoDireccionBaseTransporte);
        }

        // POST: TipoDireccionBaseTransporte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseTransporteID,DireccionID")] TipoDireccionBaseTransporte tipoDireccionBaseTransporte)
        {
            if (id != tipoDireccionBaseTransporte.BaseTransporteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDireccionBaseTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDireccionBaseTransporteExists(tipoDireccionBaseTransporte.BaseTransporteID))
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
            ViewData["BaseTransporteID"] = new SelectList(_context.BasesTransportes, "ID", "ID", tipoDireccionBaseTransporte.BaseTransporteID);
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionBaseTransporte.DireccionID);
            return View(tipoDireccionBaseTransporte);
        }

        // GET: TipoDireccionBaseTransporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionBaseTransporte = await _context.TipoDireccionBaseTransportes
                .Include(t => t.BaseTransporte)
                .Include(t => t.Direccion)
                .FirstOrDefaultAsync(m => m.BaseTransporteID == id);
            if (tipoDireccionBaseTransporte == null)
            {
                return NotFound();
            }

            return View(tipoDireccionBaseTransporte);
        }

        // POST: TipoDireccionBaseTransporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDireccionBaseTransporte = await _context.TipoDireccionBaseTransportes.FindAsync(id);
            _context.TipoDireccionBaseTransportes.Remove(tipoDireccionBaseTransporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDireccionBaseTransporteExists(int id)
        {
            return _context.TipoDireccionBaseTransportes.Any(e => e.BaseTransporteID == id);
        }
    }
}
