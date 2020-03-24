namespace CitricosCaribe.Models
{
    public class MedioAsignado
    {

        public int TrabajadorID { get; set; }
        public Trabajador Trabajador { get; set; }

        public int MedioID { get; set; }
        public Medio Medio { get; set; }

         public int Cantidad { get; set; }
    }
}