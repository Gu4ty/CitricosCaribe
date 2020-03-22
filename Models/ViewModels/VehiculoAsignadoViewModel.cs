using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CitricosCaribe.Models
{
    public class VehiculoAsignadoViewModel
    {
        [Required]
        //[Remote(controller:"VehiculoAsignado",action: "VerificarCI")]
        public int TrabajadorID { get; set; }
        public Trabajador Trabajador { get; set; }
        
        [Required]
        public int VehiculoID { get; set; }
        public Vehiculo Vehiculo { get; set; }

        List<string> Errores;
    }
}