namespace CitricosCaribe.Models
{
    public class BaseTransporte
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        //Nav
        public TipoDireccionBaseTransporte TipoDireccionBaseTransporte { get; set; }
    }
}