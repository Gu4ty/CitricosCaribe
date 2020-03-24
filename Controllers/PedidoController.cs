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
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pedidos.Include(p => p.Empresa).Include(p => p.Producto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var pedido = await _context.Pedidos
                .Include(p => p.Empresa)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,ProductoID,FechaOferta,TipoDeDivisas,Presupuesto,Cantidad,Calidad")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "ID", pedido.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", pedido.ProductoID);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime fecha = DateTime.Parse(FechaOferta);
            var pedido = await _context.Pedidos.FindAsync(ProductoID,EmpresaID,fecha);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", pedido.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", pedido.ProductoID);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EmpresaID,int ProductoID,string FechaOferta,[Bind("EmpresaID,ProductoID,FechaOferta,TipoDeDivisas,Presupuesto,Cantidad,Calidad")] Pedido pedido)
        {
            if (ProductoID != pedido.ProductoID)
            {
                return NotFound();
            }
            if (EmpresaID != pedido.EmpresaID)
            {
                return NotFound();
            }
            DateTime fecha = DateTime.Parse(FechaOferta);
            if (fecha != pedido.FechaOferta)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.ProductoID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "ID", "Discriminator", pedido.EmpresaID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ID", "Nombre", pedido.ProductoID);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? EmpresaID,int? ProductoID, string FechaOferta)
        {
            if (EmpresaID == null || ProductoID ==null || FechaOferta==null)
            {
                return NotFound();
            }
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var pedido = await _context.Pedidos
                .Include(p => p.Empresa)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductoID == ProductoID && m.EmpresaID==EmpresaID && m.FechaOferta==Fecha);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmpresaID,int ProductoID,string FechaOferta)
        {
            DateTime Fecha = DateTime.Parse(FechaOferta);
            var pedido = await _context.Pedidos.FindAsync(ProductoID,EmpresaID,Fecha);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.ProductoID == id);
        }
    }
}
