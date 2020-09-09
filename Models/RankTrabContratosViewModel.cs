using System;
using System.ComponentModel.DataAnnotations;

namespace CitricosCaribe.Models
{
    public class RankTrabContratosViewModel
    {  
        public Trabajador Trabajador { get; set; }
        public double CntCCI { get; set; }
        public double CntCCN { get; set; }
        public double CntCVI { get; set; }
        public double CntCVN { get; set; }
 
    }
}