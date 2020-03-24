using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitricosCaribe.Data;
using CitricosCaribe.Models;
using System.Data;
using CitricosCaribe.Models.ViewModels;
using CitricosCaribe.Utils;

namespace CitricosCaribe.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Productos.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var producto = await _context.Productos
            .Include(p => p.Pedidos)
                .ThenInclude(p => p.Empresa)
            .Include(p=> p.Solicitudes)
                .ThenInclude(s => s.Empresa)
            .Include(p => p.Ofertas )
                .ThenInclude(o => o.Empresa)
            .Include(p=> p.ContratoCompraNacionales)
                .ThenInclude(c => c.Empresa)
            .Include(p=> p.ContratoCompraInternacionales)
                .ThenInclude(c => c.Empresa)    
            .Include(p=> p.ContratoVentaNacionales)
                .ThenInclude(c => c.Empresa)        
            .Include(p=> p.ContratoVentaInternacionales)
                .ThenInclude(c => c.Empresa)            
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);



            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descripcion,CaracteristicasTecnicas,UnidadDeMedida")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descripcion,CaracteristicasTecnicas,UnidadDeMedida")] Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ID))
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
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ID == id);
        }
    }
}
