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
    public class ContratoCompraNacionalController : Controller
    {
        private readonly AppDbContext _context;

        public ContratoCompraNacionalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContratoCompraNacional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContratosComprasNacionales.Include(c => c.Empresa).Include(c => c.Producto).Include(c => c.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContratoCompraNacional/Details/5
        public async Task<IActionResult> Details(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraNacional = await _context.ContratosComprasNacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaPedido==fechaP && m.FechaContrato==fechaC );
            if (contratoCompraNacional == null)
            {
                return NotFound();
            }

            return View(contratoCompraNacional);
        }

        // GET: ContratoCompraNacional/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");
            return View();
        }

        // POST: ContratoCompraNacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,TrabajadorID,ProductoID,FechaPedido,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoCompraNacional contratoCompraNacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoCompraNacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoCompraNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraNacional.TrabajadorID);
            return View(contratoCompraNacional);
        }

        // GET: ContratoCompraNacional/Edit/5
        public async Task<IActionResult> Edit(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)
            {
                return NotFound();
            }
           
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraNacional = await _context.ContratosComprasNacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaP);
            if (contratoCompraNacional == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoCompraNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraNacional.TrabajadorID);
            return View(contratoCompraNacional);
        }

        // POST: ContratoCompraNacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductoID,int TrabajadorID,int EmpresaID, string FechaPedido, string FechaContrato, [Bind("EmpresaID,TrabajadorID,ProductoID,FechaPedido,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoCompraNacional contratoCompraNacional)
        {
            if (ProductoID != contratoCompraNacional.ProductoID)
            {
                return NotFound();
            }
            if (TrabajadorID != contratoCompraNacional.TrabajadorID)
            {
                return NotFound();
            }
            if (EmpresaID != contratoCompraNacional.EmpresaID)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            if (fechaP != contratoCompraNacional.FechaPedido)
            {
                return NotFound();
            }
            DateTime fechaC = DateTime.Parse(FechaContrato);
            if (fechaC != contratoCompraNacional.FechaContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoCompraNacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoCompraNacionalExists(contratoCompraNacional.EmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoCompraNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoCompraNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoCompraNacional.TrabajadorID);
            return View(contratoCompraNacional);
        }

        // GET: ContratoCompraNacional/Delete/5
        public async Task<IActionResult> Delete(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaPedido, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaPedido == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraNacional = await _context.ContratosComprasNacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaPedido==fechaP && m.FechaContrato==fechaC );
            if (contratoCompraNacional == null)
            {
                return NotFound();
            }

            return View(contratoCompraNacional);
        }

        // POST: ContratoCompraNacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductoID,int TrabajadorID,int EmpresaID, string FechaPedido, string FechaContrato)
        {
            DateTime fechaP = DateTime.Parse(FechaPedido);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoCompraNacional = await _context.ContratosComprasNacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaP);
            _context.ContratosComprasNacionales.Remove(contratoCompraNacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoCompraNacionalExists(int id)
        {
            return _context.ContratosComprasNacionales.Any(e => e.EmpresaID == id);
        }
    }
}
