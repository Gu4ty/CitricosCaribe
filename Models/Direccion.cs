
using System.Collections.Generic;

namespace CitricosCaribe.Models
{
    public class Direccion
    {
        public int ID { get; set; }
        public string Tipo { get; set; }

        //Nav
        public List<TipoDireccionTrabajador> TipoDireccionTrabajador { get; set; }
        public List<TipoDireccionBaseTransporte> TipoDireccionBaseTransportes { get; set; }
        public List<TipoDireccionFrigorifico> TipoDireccionFrigorificos { get; set; }
    }
}