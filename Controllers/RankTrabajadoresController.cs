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
    public class RankTrabajadoresController : Controller
    {
        private readonly AppDbContext _context;

        public RankTrabajadoresController(AppDbContext context)
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
                    

            List<RankTrabajadoresViewModel> vm = new List<RankTrabajadoresViewModel>();
            var trabajadores = from t in _context.Trabajadores
                            select t;
            foreach(var t in trabajadores)
            {
                var cci = await _context.ContratosComprasInternacionales.Where(c=> c.TrabajadorID == t.CI).ToListAsync();
                var ccn = await _context.ContratosComprasNacionales.Where(c=> c.TrabajadorID == t.CI).ToListAsync();
                var cvi = await _context.ContratosVentasInternacionales.Where(c=> c.TrabajadorID == t.CI).ToListAsync();
                var cvn = await _context.ContratosVentasNacionales.Where(c=> c.TrabajadorID == t.CI).ToListAsync();
                if(cci.Count==0 && ccn.Count==0 && cvi.Count==0 && cvn.Count==0)
                    continue;
                
                RankTrabajadoresViewModel rankTrab = new RankTrabajadoresViewModel();
                rankTrab.Trabajador = t;

                foreach(var c in cci)
                {
                    rankTrab.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in ccn)
                {
                    rankTrab.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in cvi)
                {
                    rankTrab.DineroGanadoCCI += c.DineroGanadoUSD;
                }
                foreach(var c in cvn)
                {
                    rankTrab.DineroGanadoCCI += c.DineroGanadoUSD;
                }

                vm.Add(rankTrab);

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
                        vm.Sort( (a,b)=>( a.Trabajador.Nombre.CompareTo(b.Trabajador.Nombre) ) );
                        break;
                }
        
            return View(vm);   
        }

    }
}
