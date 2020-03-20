
using System.Collections.Generic;

namespace CitricosCaribe.Models
{
    public class Trabajador
    {
        public int CI { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public string GradoEscolar { get; set; }
        public double Sueldo { get; set; }

        //nav
        public VehiculoAsignado VehiculoAsignado { get; set; }
        public List<MedioAsignado> MedioAsignado { get; set; }
        public List<ContratoCompraInternacional> ContratoCompraInternacionales { get; set; }
        public List<ContratoVentaNacional> ContratoVentaNacionales { get; set; }
        public TipoDireccionTrabajador TipoDireccionTrabajador{get;set;}
        public List<ContratoVentaInternacional> ContratoVentaInternacionales { get; set; }
        public List<ContratoCompraNacional> ContratoCompraNacionales{get;set;}
    }
}