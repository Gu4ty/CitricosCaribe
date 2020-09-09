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
    public class RankTrabContratosController : Controller
    {
        private readonly AppDbContext _context;

        public RankTrabContratosController(AppDbContext context)
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
                    

            List<RankTrabContratosViewModel> vm = new List<RankTrabContratosViewModel>();
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
                
                RankTrabContratosViewModel rankTrab = new RankTrabContratosViewModel();
                rankTrab.Trabajador = t;

               
                rankTrab.CntCCI = cci.Count;
                rankTrab.CntCCN = ccn.Count;
                rankTrab.CntCVI = cvi.Count;
                rankTrab.CntCVN = cvn.Count;
                

                vm.Add(rankTrab);

            }

            switch(sortOrder)
                {
                    case "cci":
                        vm.Sort( (a,b) => (a.CntCCI.CompareTo(b.CntCCI)) );
                        break;
                    case "cci_dec":
                        vm.Sort( (a,b) => (b.CntCCI.CompareTo(a.CntCCI)) );
                        break;
                    case "ccn":
                        vm.Sort( (a,b) => (a.CntCCN.CompareTo(b.CntCCN)) );
                        break;
                    case "ccn_dec":
                        vm.Sort( (a,b) => (b.CntCCN.CompareTo(a.CntCCN)) );
                        break;
                    case "cvi":
                        vm.Sort( (a,b) => (a.CntCVI.CompareTo(b.CntCVI)) );
                        break;
                    case "cvi_dec":
                        vm.Sort( (a,b) => (b.CntCVI.CompareTo(a.CntCVI)) );
                        break;
                    case "cvn":
                        vm.Sort( (a,b) => (a.CntCVN.CompareTo(b.CntCVN)) );
                        break;
                    case "cvn_dec":
                        vm.Sort( (a,b) => (b.CntCVN.CompareTo(a.CntCVN)) );
                        break;
                    default:
                        vm.Sort( (a,b)=>( a.Trabajador.Nombre.CompareTo(b.Trabajador.Nombre) ) );
                        break;
                }
        
            return View(vm);   
        }

    }
}
