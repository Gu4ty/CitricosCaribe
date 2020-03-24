using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CitricosCaribe.Models
{
    public class Solicitud
    {

        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        
        [DataType(DataType.Date)]        
        public DateTime FechaOferta { get; set; }

        public int Cantidad { get; set; }
        public double Presupuesto { get; set; }
        
        public string Calidad { get; set; }

       
       
    }
}