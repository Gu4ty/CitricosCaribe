//abla # 20 Contrato de venta nacional: IDProducto, IDEmpresa, CI,
// Fecha de contrato, Fecha de solicitud, Objeto del contrato, Tipo de pago, de una parte, 
//de la otra parte, de ambas partes, dinero ganado en usd, campos otros


using System;
using System.ComponentModel.DataAnnotations;

namespace CitricosCaribe.Models
{
    public class ContratoVentaNacional
    {
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int TrabajadorID { get; set; }
        public Trabajador Trabajador { get; set; }

        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        [DataType(DataType.Date)] 
        public DateTime FechaSolicitud { get; set; }
        [DataType(DataType.Date)] 
        public DateTime FechaContrato { get; set; }
       
       
        
        public string DeUnaParte { get; set; }
        public string DeLaOtraParte { get; set; }
        public string DeAmbasPartes { get; set; }
         
        public string ObjetoDelContrato { get; set; }
        public string TipoPago { get; set; }
        public double DineroGanadoUSD { get; set; }
        public string CamposOtros { get; set; }


    }
}