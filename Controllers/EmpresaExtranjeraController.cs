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
    public class EmpresaExtranjeraController : Controller
    {
        private readonly AppDbContext _context;

        public EmpresaExtranjeraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpresaExtranjera
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpresasExtranjeras.ToListAsync());
        }

        // GET: EmpresaExtranjera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaExtranjera = await _context.EmpresasExtranjeras
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empresaExtranjera == null)
            {
                return NotFound();
            }

            return View(empresaExtranjera);
        }

        // GET: EmpresaExtranjera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpresaExtranjera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pais,ID,Name")] EmpresaExtranjera empresaExtranjera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaExtranjera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresaExtranjera);
        }

        // GET: EmpresaExtranjera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaExtranjera = await _context.EmpresasExtranjeras.FindAsync(id);
            if (empresaExtranjera == null)
            {
                return NotFound();
            }
            return View(empresaExtranjera);
        }

        // POST: EmpresaExtranjera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pais,ID,Name")] EmpresaExtranjera empresaExtranjera)
        {
            if (id != empresaExtranjera.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaExtranjera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExtranjeraExists(empresaExtranjera.ID))
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
            return View(empresaExtranjera);
        }

        // GET: EmpresaExtranjera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaExtranjera = await _context.EmpresasExtranjeras
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empresaExtranjera == null)
            {
                return NotFound();
            }

            return View(empresaExtranjera);
        }

        // POST: EmpresaExtranjera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaExtranjera = await _context.EmpresasExtranjeras.FindAsync(id);
            _context.EmpresasExtranjeras.Remove(empresaExtranjera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExtranjeraExists(int id)
        {
            return _context.EmpresasExtranjeras.Any(e => e.ID == id);
        }
    }
}
