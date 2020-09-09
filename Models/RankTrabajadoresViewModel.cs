using System;
using System.ComponentModel.DataAnnotations;

namespace CitricosCaribe.Models
{
    public class RankTrabajadoresViewModel
    {  
        public Trabajador Trabajador { get; set; }
        public double DineroGanadoCCI { get; set; }
        public double DineroGanadoCCN { get; set; }
        public double DineroGanadoCVI { get; set; }
        public double DineroGanadoCVN { get; set; }
 
    }
}