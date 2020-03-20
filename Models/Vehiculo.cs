using System.Collections.Generic;

namespace CitricosCaribe.Models
{
    public class Vehiculo
    {
        public int ID { get; set; }
        public string Motor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        //Nav
        public VehiculoAsignado VehiculoAsignado { get; set; }
    }
}