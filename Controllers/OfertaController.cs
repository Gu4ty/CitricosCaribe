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
    public class OfertaController : Controller
    {
        private readonly AppDbContext _context;

        public OfertaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Oferta
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Ofertas.Include(o => o.Empresa).Include(o => o.Producto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Oferta/Details/5
        public async Task<IActionResult> Details(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var oferta = await _context.Ofertas
                .Include(o => o.Empresa)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // GET: Oferta/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            return View();
        }

        // POST: Oferta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,ProductoID,FechaOferta,Origen,Cantidad,PuertoOrigen,PuertoDestino,Calidad")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", oferta.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", oferta.ProductoID);
            return View(oferta);
        }

        // GET: Oferta/Edit/5
        public async Task<IActionResult> Edit(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
              DateTime fecha = DateTime.Parse(FechaOferta);
            var oferta = await _context.Ofertas.FindAsync(ProductoID,EmpresaID,fecha);
            if (oferta == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", oferta.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", oferta.ProductoID);
            return View(oferta);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EmpresaID,int ProductoID,string FechaOferta, [Bind("EmpresaID,ProductoID,FechaOferta,Origen,Cantidad,PuertoOrigen,PuertoDestino,Calidad")] Oferta oferta)
        {
            if (ProductoID != oferta.ProductoID)
            {
                return NotFound();
            }
            if (EmpresaID != oferta.EmpresaID)
            {
                return NotFound();
            }
            DateTime fecha = DateTime.Parse(FechaOferta);
            if (fecha != oferta.FechaOferta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.ProductoID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", oferta.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", oferta.ProductoID);
            return View(oferta);
        }

        // GET: Oferta/Delete/5
        public async Task<IActionResult> Delete(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var oferta = await _context.Ofertas
                .Include(o => o.Empresa)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmpresaID,int ProductoID,string FechaOferta)
        {
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var oferta = await _context.Ofertas.FindAsync(ProductoID,EmpresaID,Fecha);
            _context.Ofertas.Remove(oferta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaExists(int id)
        {
            return _context.Ofertas.Any(e => e.ProductoID == id);
        }
    }
}
