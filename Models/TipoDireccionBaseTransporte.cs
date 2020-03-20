namespace CitricosCaribe.Models
{
    public class TipoDireccionBaseTransporte
    {

        public int BaseTransporteID { get; set; }
        public BaseTransporte BaseTransporte { get; set; }

        public int DireccionID { get; set; }
        public Direccion Direccion { get; set; }
    }
}