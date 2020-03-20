namespace CitricosCaribe.Models
{
    public class TipoDireccionFrigorifico
    {   
        public int FrigorificoID { get; set; }
        public Frigorifico Frigorifico { get; set; }
        public int DireccionID { get; set; }
        public Direccion Direccion { get; set; }
    }
}