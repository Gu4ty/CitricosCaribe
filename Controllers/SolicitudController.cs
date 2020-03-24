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
    public class SolicitudController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitud
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Solicitudes.Include(s => s.Empresa).Include(s => s.Producto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Solicitud/Details/5
        public async Task<IActionResult> Details(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var solicitud = await _context.Solicitudes
                .Include(s => s.Empresa)
                .Include(s => s.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "ID");
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,ProductoID,FechaOferta,Cantidad,Presupuesto,Calidad")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", solicitud.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", solicitud.ProductoID);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public async Task<IActionResult> Edit(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime fecha = DateTime.Parse(FechaOferta);
            var solicitud = await _context.Solicitudes.FindAsync(ProductoID,EmpresaID,fecha);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", solicitud.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "ID", solicitud.ProductoID);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EmpresaID,int ProductoID,string FechaOferta,[Bind("EmpresaID,ProductoID,FechaOferta,Cantidad,Presupuesto,Calidad")] Solicitud solicitud)
        {
            if (ProductoID != solicitud.ProductoID)
            {
                return NotFound();
            }
            if (EmpresaID != solicitud.EmpresaID)
            {
                return NotFound();
            }
            DateTime fecha = DateTime.Parse(FechaOferta);
            if (fecha != solicitud.FechaOferta)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.ProductoID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", solicitud.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", solicitud.ProductoID);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public async Task<IActionResult> Delete(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var solicitud = await _context.Solicitudes
                .Include(s => s.Empresa)
                .Include(s => s.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmpresaID,int ProductoID,string FechaOferta)
        {
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var solicitud = await _context.Solicitudes.FindAsync(ProductoID,EmpresaID,Fecha);
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitudes.Any(e => e.ProductoID == id);
        }
    }
}
