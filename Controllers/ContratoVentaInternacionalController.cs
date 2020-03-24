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
    public class ContratoVentaInternacionalController : Controller
    {
        private readonly AppDbContext _context;

        public ContratoVentaInternacionalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContratoVentaInternacional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContratosVentasInternacionales.Include(c => c.Empresa).Include(c => c.Producto).Include(c => c.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContratoVentaInternacional/Details/5
        public async Task<IActionResult> Details(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaInternacional = await _context.ContratosVentasInternacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaPedido==fechaP && m.FechaContrato==fechaC );
            if (contratoVentaInternacional == null)
            {
                return NotFound();
            }

            return View(contratoVentaInternacional);
        }

        // GET: ContratoVentaInternacional/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            return View();
        }

        // POST: ContratoVentaInternacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,TrabajadorID,ProductoID,FechaPedido,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoVentaInternacional contratoVentaInternacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoVentaInternacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoVentaInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaInternacional.TrabajadorID);
            return View(contratoVentaInternacional);
        }

        // GET: ContratoVentaInternacional/Edit/5
        public async Task<IActionResult> Edit(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)

            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaInternacional = await _context.ContratosVentasInternacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaP);
            if (contratoVentaInternacional == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoVentaInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaInternacional.TrabajadorID);
            return View(contratoVentaInternacional);
        }

        // POST: ContratoVentaInternacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductoID,int TrabajadorID,int EmpresaID, string FechaPedido, string FechaContrato,[Bind("EmpresaID,TrabajadorID,ProductoID,FechaPedido,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoVentaInternacional contratoVentaInternacional)
        {
            if (ProductoID != contratoVentaInternacional.ProductoID)
            {
                return NotFound();
            }
            if (TrabajadorID != contratoVentaInternacional.TrabajadorID)
            {
                return NotFound();
            }
            if (EmpresaID != contratoVentaInternacional.EmpresaID)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            if (fechaP != contratoVentaInternacional.FechaPedido)
            {
                return NotFound();
            }
            DateTime fechaC = DateTime.Parse(FechaContrato);
            if (fechaC != contratoVentaInternacional.FechaContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoVentaInternacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoVentaInternacionalExists(contratoVentaInternacional.EmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoVentaInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaInternacional.TrabajadorID);
            return View(contratoVentaInternacional);
        }

        // GET: ContratoVentaInternacional/Delete/5
        public async Task<IActionResult> Delete(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaInternacional = await _context.ContratosVentasInternacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaPedido==fechaP && m.FechaContrato==fechaC );
            if (contratoVentaInternacional == null)
            {
                return NotFound();
            }

            return View(contratoVentaInternacional);
        }

        // POST: ContratoVentaInternacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductoID,int TrabajadorID,int EmpresaID, string FechaPedido, string FechaContrato)
        {
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaInternacional = await _context.ContratosVentasInternacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaP);
            _context.ContratosVentasInternacionales.Remove(contratoVentaInternacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoVentaInternacionalExists(int id)
        {
            return _context.ContratosVentasInternacionales.Any(e => e.EmpresaID == id);
        }
    }
}
