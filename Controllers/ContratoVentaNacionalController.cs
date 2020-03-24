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
    public class ContratoVentaNacionalController : Controller
    {
        private readonly AppDbContext _context;

        public ContratoVentaNacionalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContratoVentaNacional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContratosVentasNacionales.Include(c => c.Empresa).Include(c => c.Producto).Include(c => c.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContratoVentaNacional/Details/5
        public async Task<IActionResult> Details(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaSolicitud, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaSolicitud == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaS = DateTime.Parse(FechaSolicitud);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaNacional = await _context.ContratosVentasNacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaSolicitud==fechaS && m.FechaContrato==fechaC );
            if (contratoVentaNacional == null)
            {
                return NotFound();
            }

            return View(contratoVentaNacional);
        }

        // GET: ContratoVentaNacional/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI");

            return View();
        }

        // POST: ContratoVentaNacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,TrabajadorID,ProductoID,FechaSolicitud,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoVentaNacional contratoVentaNacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoVentaNacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoVentaNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaNacional.TrabajadorID);
            return View(contratoVentaNacional);
        }

        // GET: ContratoVentaNacional/Edit/5
        public async Task<IActionResult> Edit(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaSolicitud, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaSolicitud == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaS = DateTime.Parse(FechaSolicitud);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaNacional = await _context.ContratosVentasNacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaS);
            if (contratoVentaNacional == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", contratoVentaNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaNacional.TrabajadorID);
            return View(contratoVentaNacional);
        }

        // POST: ContratoVentaNacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductoID,int TrabajadorID,int EmpresaID, string FechaSolicitud, string FechaContrato, [Bind("EmpresaID,TrabajadorID,ProductoID,FechaSolicitud,FechaContrato,DeUnaParte,DeLaOtraParte,DeAmbasPartes,ObjetoDelContrato,TipoPago,DineroGanadoUSD,CamposOtros")] ContratoVentaNacional contratoVentaNacional)
        {
            if (ProductoID != contratoVentaNacional.ProductoID)
            {
                return NotFound();
            }
            if (TrabajadorID != contratoVentaNacional.TrabajadorID)
            {
                return NotFound();
            }
            if (EmpresaID != contratoVentaNacional.EmpresaID)
            {
                return NotFound();
            }
            DateTime fechaO = DateTime.Parse(FechaSolicitud);
            if (fechaO != contratoVentaNacional.FechaSolicitud)
            {
                return NotFound();
            }
            DateTime fechaC = DateTime.Parse(FechaContrato);
            if (fechaC != contratoVentaNacional.FechaContrato)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoVentaNacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoVentaNacionalExists(contratoVentaNacional.EmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", contratoVentaNacional.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", contratoVentaNacional.ProductoID);
            ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "CI", "CI", contratoVentaNacional.TrabajadorID);
            return View(contratoVentaNacional);
        }

        // GET: ContratoVentaNacional/Delete/5
        public async Task<IActionResult> Delete(int? ProductoID,int? TrabajadorID,int? EmpresaID, string FechaSolicitud, string FechaContrato)
        {
            if (ProductoID == null || TrabajadorID == null || EmpresaID == null || FechaSolicitud == null || FechaContrato == null)
            {
                return NotFound();
            }
            DateTime fechaS = DateTime.Parse(FechaSolicitud);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaNacional = await _context.ContratosVentasNacionales
                .Include(c => c.Empresa)
                .Include(c => c.Producto)
                .Include(c => c.Trabajador)
                .FirstOrDefaultAsync(m => m.EmpresaID == EmpresaID && m.ProductoID==ProductoID 
                && m.TrabajadorID==TrabajadorID 
                && m.FechaSolicitud==fechaS && m.FechaContrato==fechaC );
            if (contratoVentaNacional == null)
            {
                return NotFound();
            }

            return View(contratoVentaNacional);
        }

        // POST: ContratoVentaNacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductoID,int TrabajadorID,int EmpresaID, string FechaSolicitud, string FechaContrato)
        {
            DateTime fechaS = DateTime.Parse(FechaSolicitud);
            DateTime fechaC = DateTime.Parse(FechaContrato);
            var contratoVentaNacional = await _context.ContratosVentasNacionales.FindAsync(EmpresaID,TrabajadorID,ProductoID,fechaC,fechaS);
            _context.ContratosVentasNacionales.Remove(contratoVentaNacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoVentaNacionalExists(int id)
        {
            return _context.ContratosVentasNacionales.Any(e => e.EmpresaID == id);
        }
    }
}
