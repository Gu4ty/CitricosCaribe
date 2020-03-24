using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CitricosCaribe.Models
{
    public class Producto
    {  
        public int ID { get; set; }
        [Required]
        //[Remote(controller:"Producto",action: "VerificarNombre")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CaracteristicasTecnicas { get; set; }
        public string UnidadDeMedida { get; set; }

        //Nav
        public List<Solicitud> Solicitudes { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Oferta> Ofertas { get; set; }
        public List<ContratoCompraInternacional> ContratoCompraInternacionales { get; set; }
        public List<ContratoVentaNacional> ContratoVentaNacionales { get; set; }
        public List<ContratoVentaInternacional> ContratoVentaInternacionales { get; set; }
        public List<ContratoCompraNacional> ContratoCompraNacionales{get;set;}
        
    }
}