namespace CitricosCaribe.Models
{
    public class Frigorifico
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        //Nav
        public TipoDireccionFrigorifico TipoDireccionFrigorifico { get; set; }
    }
}