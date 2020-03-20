using System.Collections.Generic;

namespace CitricosCaribe.Models
{
    public class Medio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        //Nav
        public List<MedioAsignado> MedioAsignado { get; set; }
    }
}