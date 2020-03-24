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
    public class MedioAsignadoController : Controller
    {
        private readonly AppDbContext _context;

        public MedioAsignadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MedioAsignado
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MediosAsignados.Include(m => m.Medio).Include(m => m.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MedioAsignado/Details/5
        public async Task<IActionResult> Details(int? TrabajadorID, int? MedioID )
        {
           
            if (MedioID ==null || TrabajadorID == null)
            {
                
                return NotFound();
            }

            var medioAsignado = await _context.MediosAsignados
                .Include(m => m.Medio)
                .Include(m => m.Trabajador)
                .FirstOrDefaultAsync(m => m.TrabajadorID == TrabajadorID && m.MedioID == MedioID);
            if (medioAsignado == null)
            {
                
                return NotFound();
            }
            
            return View(medioAsignado);
        }

        // GET: MedioAsignado/Create
        public IActionResult Create()
        {
            
            ViewData["MedioID"] = new SelectList(_context.Medios, "ID", "ID");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            return View();
        }

        // POST: MedioAsignado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrabajadorID,MedioID,Cantidad")] MedioAsignado medioAsignado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medioAsignado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedioID"] = new SelectList(_context.Medios, "ID", "ID", medioAsignado.MedioID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", medioAsignado.TrabajadorID);
            return View(medioAsignado);
        }

        // GET: MedioAsignado/Edit/5
        public async Task<IActionResult> Edit(int? TrabajadorID, int? MedioID )
        {
            if (TrabajadorID == null || MedioID==null )
            {
                return NotFound();
            }

            var medioAsignado = await _context.MediosAsignados.FindAsync(TrabajadorID,MedioID);
            if (medioAsignado == null)
            {
                return NotFound();
            }
            ViewData["MedioID"] = new SelectList(_context.Medios, "ID", "ID", medioAsignado.MedioID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", medioAsignado.TrabajadorID);
            return View(medioAsignado);
        }

        // POST: MedioAsignado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int TrabajadorID,int MedioID, [Bind("TrabajadorID,MedioID,Cantidad")] MedioAsignado medioAsignado)
        {
            if (TrabajadorID != medioAsignado.TrabajadorID)
            {
                return NotFound();
            }
            if (MedioID != medioAsignado.MedioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medioAsignado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedioAsignadoExists(medioAsignado.TrabajadorID))
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
            ViewData["MedioID"] = new SelectList(_context.Medios, "ID", "ID", medioAsignado.MedioID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", medioAsignado.TrabajadorID);
            return View(medioAsignado);
        }

        // GET: MedioAsignado/Delete/5
        public async Task<IActionResult> Delete(int? TrabajadorID, int? MedioID)
        {
             if (MedioID ==null || TrabajadorID == null)
            {
                
                return NotFound();
            }

            var medioAsignado = await _context.MediosAsignados
                .Include(m => m.Medio)
                .Include(m => m.Trabajador)
                .FirstOrDefaultAsync(m => m.TrabajadorID == TrabajadorID && m.MedioID == MedioID);
            if (medioAsignado == null)
            {
                return NotFound();
            }

            return View(medioAsignado);
        }

        // POST: MedioAsignado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int TrabajadorID, int MedioID)
        {
            var medioAsignado = await _context.MediosAsignados.FindAsync(TrabajadorID,MedioID);
            _context.MediosAsignados.Remove(medioAsignado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedioAsignadoExists(int id)
        {
            return _context.MediosAsignados.Any(e => e.TrabajadorID == id);
        }
    }
}
