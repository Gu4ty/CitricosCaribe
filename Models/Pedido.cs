using System;

namespace CitricosCaribe.Models
{
    public class Pedido
    {

        public string TipoDeDivisas { get; set; }

        public DateTime FechaOferta { get; set; }
        public double Presupuesto { get; set; }
        public int Cantidad { get; set; }
        public string Calidad { get; set; }

        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
    }
}