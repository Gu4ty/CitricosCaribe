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
    public class EmpresaNacionalController : Controller
    {
        private readonly AppDbContext _context;

        public EmpresaNacionalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpresaNacional
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpresasNacionales.ToListAsync());
        }

        // GET: EmpresaNacional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaNacional = await _context.EmpresasNacionales
                .Include(e => e.Pedidos)
                    .ThenInclude(p => p.Producto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
                
            if (empresaNacional == null)
            {
                return NotFound();
            }

            return View(empresaNacional);
        }

        // GET: EmpresaNacional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpresaNacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Provincia,ID,Name")] EmpresaNacional empresaNacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaNacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresaNacional);
        }

        // GET: EmpresaNacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaNacional = await _context.EmpresasNacionales.FindAsync(id);
            if (empresaNacional == null)
            {
                return NotFound();
            }
            return View(empresaNacional);
        }

        // POST: EmpresaNacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Provincia,ID,Name")] EmpresaNacional empresaNacional)
        {
            if (id != empresaNacional.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaNacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaNacionalExists(empresaNacional.ID))
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
            return View(empresaNacional);
        }

        // GET: EmpresaNacional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaNacional = await _context.EmpresasNacionales
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empresaNacional == null)
            {
                return NotFound();
            }

            return View(empresaNacional);
        }

        // POST: EmpresaNacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaNacional = await _context.EmpresasNacionales.FindAsync(id);
            _context.EmpresasNacionales.Remove(empresaNacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaNacionalExists(int id)
        {
            return _context.EmpresasNacionales.Any(e => e.ID == id);
        }
    }
}
