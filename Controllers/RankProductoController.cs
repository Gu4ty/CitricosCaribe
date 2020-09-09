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
    public class RankProductoController : Controller
    {
        private readonly AppDbContext _context;

        public RankProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Frigorifico
        public async Task<IActionResult> Index(string sortOrder)
        {

            ViewData["CCISortParm"] = sortOrder == "cci" ? "cci_dec" : "cci";
            ViewData["CCNSortParm"] = sortOrder == "ccn" ? "ccn_dec" : "ccn";
            ViewData["CVISortParm"] = sortOrder == "cvi" ? "cvi_desc" : "cvi";
            ViewData["CVNSortParm"] = sortOrder == "cvn" ? "cvn_dec" : "cvn";
                    

            List<RankProductoViewModel> vm = new List<RankProductoViewModel>();
            var productos = from p in _context.Productos
                            select p;
            foreach(var p in productos)
            {
                var cci = await _context.ContratosComprasInternacionales.Where(c=> c.ProductoID == p.ID).ToListAsync();
                var ccn = await _context.ContratosComprasNacionales.Where(c=> c.ProductoID == p.ID).ToListAsync();
                var cvi = await _context.ContratosVentasInternacionales.Where(c=> c.ProductoID == p.ID).ToListAsync();
                var cvn = await _context.ContratosVentasNacionales.Where(c=> c.ProductoID == p.ID).ToListAsync();
                if(cci.Count==0 && ccn.Count==0 && cvi.Count==0 && cvn.Count==0)
                    continue;
                
                RankProductoViewModel rankProduct = new RankProductoViewModel();
                rankProduct.Producto = p;
                foreach(var c in cci)
                {
                    rankProduct.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in ccn)
                {
                    rankProduct.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in cvi)
                {
                    rankProduct.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in cvn)
                {
                    rankProduct.DineroGanadoCCI += c.DineroGanadoUSD;
                }

                vm.Add(rankProduct);

            }

            switch(sortOrder)
                {
                    case "cci":
                        vm.Sort( (a,b) => (a.DineroGanadoCCI.CompareTo(b.DineroGanadoCCI)) );
                        break;
                    case "cci_dec":
                        vm.Sort( (a,b) => (b.DineroGanadoCCI.CompareTo(a.DineroGanadoCCI)) );
                        break;
                    case "ccn":
                        vm.Sort( (a,b) => (a.DineroGanadoCCN.CompareTo(b.DineroGanadoCCN)) );
                        break;
                    case "ccn_dec":
                        vm.Sort( (a,b) => (b.DineroGanadoCCN.CompareTo(a.DineroGanadoCCN)) );
                        break;
                    case "cvi":
                        vm.Sort( (a,b) => (a.DineroGanadoCVI.CompareTo(b.DineroGanadoCVI)) );
                        break;
                    case "cvi_dec":
                        vm.Sort( (a,b) => (b.DineroGanadoCVI.CompareTo(a.DineroGanadoCVI)) );
                        break;
                    case "cvn":
                        vm.Sort( (a,b) => (a.DineroGanadoCVN.CompareTo(b.DineroGanadoCVN)) );
                        break;
                    case "cvn_dec":
                        vm.Sort( (a,b) => (b.DineroGanadoCVN.CompareTo(a.DineroGanadoCVN)) );
                        break;
                    default:
                        vm.Sort( (a,b)=>( a.Producto.Nombre.CompareTo(b.Producto.Nombre) ) );
                        break;
                }
        
            return View(vm);   
        }

    }
}
