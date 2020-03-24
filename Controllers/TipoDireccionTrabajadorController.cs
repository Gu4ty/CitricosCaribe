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
    public class TipoDireccionTrabajadorController : Controller
    {
        private readonly AppDbContext _context;

        public TipoDireccionTrabajadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoDireccionTrabajador
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TipoDireccionTrabajadores.Include(t => t.Direccion).Include(t => t.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TipoDireccionTrabajador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionTrabajador = await _context.TipoDireccionTrabajadores
                .Include(t => t.Direccion)
                .Include(t => t.Trabajador)
                .FirstOrDefaultAsync(m => m.TrabajadorID == id);
            if (tipoDireccionTrabajador == null)
            {
                return NotFound();
            }

            return View(tipoDireccionTrabajador);
        }

        // GET: TipoDireccionTrabajador/Create
        public IActionResult Create()
        {
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            return View();
        }

        // POST: TipoDireccionTrabajador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrabajadorID,DireccionID")] TipoDireccionTrabajador tipoDireccionTrabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDireccionTrabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionTrabajador.DireccionID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", tipoDireccionTrabajador.TrabajadorID);
            return View(tipoDireccionTrabajador);
        }

        // GET: TipoDireccionTrabajador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionTrabajador = await _context.TipoDireccionTrabajadores.FindAsync(id);
            if (tipoDireccionTrabajador == null)
            {
                return NotFound();
            }
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionTrabajador.DireccionID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", tipoDireccionTrabajador.TrabajadorID);
            return View(tipoDireccionTrabajador);
        }

        // POST: TipoDireccionTrabajador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrabajadorID,DireccionID")] TipoDireccionTrabajador tipoDireccionTrabajador)
        {
            if (id != tipoDireccionTrabajador.TrabajadorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDireccionTrabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDireccionTrabajadorExists(tipoDireccionTrabajador.TrabajadorID))
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
            ViewData["DireccionID"] = new SelectList(_context.Direcciones, "ID", "ID", tipoDireccionTrabajador.DireccionID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", tipoDireccionTrabajador.TrabajadorID);
            return View(tipoDireccionTrabajador);
        }

        // GET: TipoDireccionTrabajador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDireccionTrabajador = await _context.TipoDireccionTrabajadores
                .Include(t => t.Direccion)
                .Include(t => t.Trabajador)
                .FirstOrDefaultAsync(m => m.TrabajadorID == id);
            if (tipoDireccionTrabajador == null)
            {
                return NotFound();
            }

            return View(tipoDireccionTrabajador);
        }

        // POST: TipoDireccionTrabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDireccionTrabajador = await _context.TipoDireccionTrabajadores.FindAsync(id);
            _context.TipoDireccionTrabajadores.Remove(tipoDireccionTrabajador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDireccionTrabajadorExists(int id)
        {
            return _context.TipoDireccionTrabajadores.Any(e => e.TrabajadorID == id);
        }
    }
}
