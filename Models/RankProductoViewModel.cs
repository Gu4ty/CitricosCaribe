using System;
using System.ComponentModel.DataAnnotations;

namespace CitricosCaribe.Models
{
    public class RankProductoViewModel
    {  
        public Producto Producto { get; set; }
        public double DineroGanadoCCI { get; set; }
        public double DineroGanadoCCN { get; set; }
        public double DineroGanadoCVI { get; set; }
        public double DineroGanadoCVN { get; set; }
 
    }
}