//Tabla # 18 Oferta:  IDProducto, IDEmpresa, 
//Fecha de oferta, Origen, Cantidad, Puerto de origen, Puerto de destino, Cantidad

using System;

namespace CitricosCaribe.Models
{
    public class Oferta
    {
        
        public DateTime FechaOferta { get; set; }
        public string Origen { get; set; }
        public int Cantidad { get; set; }
        public string PuertoOrigen { get; set; }
        public string PuertoDestino { get; set; }
        public string Calidad { get; set; }
        
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
    }
}