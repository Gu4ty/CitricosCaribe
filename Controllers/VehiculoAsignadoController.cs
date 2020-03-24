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
    public class VehiculoAsignadoController : Controller
    {
        private readonly AppDbContext _context;
       

        public VehiculoAsignadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VehiculoAsignado
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.VehiculosAsignados.Include(v => v.Trabajador).Include(v => v.Vehiculo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: VehiculoAsignado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoAsignado = await _context.VehiculosAsignados
                .Include(v => v.Trabajador)
                .Include(v => v.Vehiculo)
                .FirstOrDefaultAsync(m => m.VehiculoID == id);
            if (vehiculoAsignado == null)
            {
                return NotFound();
            }

            return View(vehiculoAsignado);
        }

        // GET: VehiculoAsignado/Create
        public IActionResult Create()
        {
            
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            ViewData["VehiculoID"] = new SelectList(_context.Vehiculos, "ID", "ID");
            return View();
        }

        // POST: VehiculoAsignado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrabajadorID,VehiculoID")] VehiculoAsignado vehiculoAsignado)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(vehiculoAsignado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", vehiculoAsignado.TrabajadorID);
            ViewData["VehiculoID"] = new SelectList(_context.Vehiculos, "ID", "ID", vehiculoAsignado.VehiculoID);
            return View(vehiculoAsignado);
        }

        // GET: VehiculoAsignado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoAsignado = await _context.VehiculosAsignados.FindAsync(id);
            if (vehiculoAsignado == null)
            {
                return NotFound();
            }
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", vehiculoAsignado.TrabajadorID);
            ViewData["VehiculoID"] = new SelectList(_context.Vehiculos, "ID", "ID", vehiculoAsignado.VehiculoID);
            return View(vehiculoAsignado);
        }

        // POST: VehiculoAsignado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrabajadorID,VehiculoID")] VehiculoAsignado vehiculoAsignado)
        {
            if (id != vehiculoAsignado.VehiculoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoAsignado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoAsignadoExists(vehiculoAsignado.VehiculoID))
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
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", vehiculoAsignado.TrabajadorID);
            ViewData["VehiculoID"] = new SelectList(_context.Vehiculos, "ID", "ID", vehiculoAsignado.VehiculoID);
            return View(vehiculoAsignado);
        }

        // GET: VehiculoAsignado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoAsignado = await _context.VehiculosAsignados
                .Include(v => v.Trabajador)
                .Include(v => v.Vehiculo)
                .FirstOrDefaultAsync(m => m.VehiculoID == id);
            if (vehiculoAsignado == null)
            {
                return NotFound();
            }

            return View(vehiculoAsignado);
        }

        // POST: VehiculoAsignado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculoAsignado = await _context.VehiculosAsignados.FindAsync(id);
            _context.VehiculosAsignados.Remove(vehiculoAsignado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoAsignadoExists(int id)
        {
            return _context.VehiculosAsignados.Any(e => e.VehiculoID == id);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerificarCI(string CI){
            
            var trabajador = await _context.Trabajadores.FindAsync(CI);
            if(trabajador == null){
                return Json(data:true);
            }

            return Json(data:$"CI {CI} Este trabajador ya tiene asignado un vehiculo.");
        }
    }
}
