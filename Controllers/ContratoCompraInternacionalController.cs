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
    public class ContratoCompraInternacionalController : Controller
    {
        private readonly AppDbContext _context;

        public ContratoCompraInternacionalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContratoCompraInternacional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContratosComprasInternacionales.Include(c => c.Empresa).Include(c => c.Producto).Include(c => c.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContratoCompraInternacional/Details/5
        public async Task<IActionResult> Details(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaOferta, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaOferta == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaO = DateTime.Parse(FechaOferta);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraInternacional = await _context.ContratosComprasInternacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaOferta==fechaO && m.FechaContrato==fechaC );
            if (contratoCompraInternacional == null)
            {
                return NotFound();
            }

            return View(contratoCompraInternacional);
        }

        // GET: ContratoCompraInternacional/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            return View();
        }

        // POST: ContratoCompraInternacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,TrabajadorID,ProductoID,FechaOferta,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoCompraInternacional contratoCompraInternacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoCompraInternacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoCompraInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraInternacional.TrabajadorID);
            return View(contratoCompraInternacional);
        }

        // GET: ContratoCompraInternacional/Edit/5
        public async Task<IActionResult> Edit(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaOferta, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaOferta == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaO = DateTime.Parse(FechaOferta);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraInternacional = await _context.ContratosComprasInternacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaO);
            if (contratoCompraInternacional == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoCompraInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraInternacional.TrabajadorID);
            return View(contratoCompraInternacional);
        }

        // POST: ContratoCompraInternacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductoID,int TrabajadorID,int EmpresaID, string FechaOferta, string FechaContrato, [Bind("EmpresaID,TrabajadorID,ProductoID,FechaOferta,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoCompraInternacional contratoCompraInternacional)
        {
            if (ProductoID != contratoCompraInternacional.ProductoID)
            {
                return NotFound();
            }
            if (TrabajadorID != contratoCompraInternacional.TrabajadorID)
            {
                return NotFound();
            }
            if (EmpresaID != contratoCompraInternacional.EmpresaID)
            {
                return NotFound();
            }
            DateTime fechaO = DateTime.Parse(FechaOferta);
            if (fechaO != contratoCompraInternacional.FechaOferta)
            {
                return NotFound();
            }
            DateTime fechaC = DateTime.Parse(FechaContrato);
            if (fechaC != contratoCompraInternacional.FechaContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoCompraInternacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoCompraInternacionalExists(contratoCompraInternacional.EmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoCompraInternacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraInternacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraInternacional.TrabajadorID);
            return View(contratoCompraInternacional);
        }

        // GET: ContratoCompraInternacional/Delete/5
        public async Task<IActionResult> Delete(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaOferta, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaOferta == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaO = DateTime.Parse(FechaOferta);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraInternacional = await _context.ContratosComprasInternacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaOferta==fechaO && m.FechaContrato==fechaC );
            if (contratoCompraInternacional == null)
            {
                return NotFound();
            }

            return View(contratoCompraInternacional);
        }

        // POST: ContratoCompraInternacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductoID,int TrabajadorID,int EmpresaID, string FechaOferta, string FechaContrato)
        {
            DateTime fechaO = DateTime.Parse(FechaOferta);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraInternacional = await _context.ContratosComprasInternacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaO);
            _context.ContratosComprasInternacionales.Remove(contratoCompraInternacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoCompraInternacionalExists(int id)
        {
            return _context.ContratosComprasInternacionales.Any(e => e.EmpresaID == id);
        }
    }
}
