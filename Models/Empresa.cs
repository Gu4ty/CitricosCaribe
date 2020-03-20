using System;
using System.Collections.Generic;


namespace CitricosCaribe.Models
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Name { get; set; }

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