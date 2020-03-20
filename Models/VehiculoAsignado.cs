using System.ComponentModel.DataAnnotations.Schema;

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