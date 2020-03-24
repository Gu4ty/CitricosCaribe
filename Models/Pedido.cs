using System;
using System.ComponentModel.DataAnnotations;

namespace CitricosCaribe.Models
{
    public class Pedido
    {   
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        [DataType(DataType.Date)]    
        public DateTime FechaOferta { get; set; }
        public string TipoDeDivisas { get; set; }
 
        public double Presupuesto { get; set; }
        public int Cantidad { get; set; }
        public string Calidad { get; set; }


    }
}