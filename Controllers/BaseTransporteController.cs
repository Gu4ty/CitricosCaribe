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
    public class BaseTransporteController : Controller
    {
        private readonly AppDbContext _context;

        public BaseTransporteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BaseTransporte
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasesTransportes.ToListAsync());
        }

        // GET: BaseTransporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTransporte = await _context.BasesTransportes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baseTransporte == null)
            {
                return NotFound();
            }

            return View(baseTransporte);
        }

        // GET: BaseTransporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseTransporte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Direccion")] BaseTransporte baseTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseTransporte);
        }

        // GET: BaseTransporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTransporte = await _context.BasesTransportes.FindAsync(id);
            if (baseTransporte == null)
            {
                return NotFound();
            }
            return View(baseTransporte);
        }

        // POST: BaseTransporte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Direccion")] BaseTransporte baseTransporte)
        {
            if (id != baseTransporte.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseTransporteExists(baseTransporte.ID))
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
            return View(baseTransporte);
        }

        // GET: BaseTransporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTransporte = await _context.BasesTransportes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baseTransporte == null)
            {
                return NotFound();
            }

            return View(baseTransporte);
        }

        // POST: BaseTransporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseTransporte = await _context.BasesTransportes.FindAsync(id);
            _context.BasesTransportes.Remove(baseTransporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseTransporteExists(int id)
        {
            return _context.BasesTransportes.Any(e => e.ID == id);
        }
    }
}
