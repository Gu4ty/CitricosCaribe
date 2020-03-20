namespace CitricosCaribe.Models
{
    public class TipoDireccionTrabajador
    {
        public int TrabajadorID { get; set; }
        public Trabajador Trabajador { get; set; }
        public int DireccionID { get; set; }
        public Direccion Direccion { get; set; }
    }
}