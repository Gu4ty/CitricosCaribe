using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CitricosCaribe.Models
{
    public class VehiculoAsignado
    {
        
        public int TrabajadorID { get; set; }
        public Trabajador Trabajador { get; set; }
        
    
        public int VehiculoID { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}