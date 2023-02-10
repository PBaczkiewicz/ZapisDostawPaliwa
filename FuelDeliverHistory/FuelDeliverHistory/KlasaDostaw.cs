using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelDeliverHistory
{
    public class Dostawy
    {
        public DateTime data { get; set; }
        
        public int iloscPaliwa { get; set; }
        public double nettoLitr { get; set; }
        public double bruttoLitr { get;set; }
        public double cenaNetto { get; set; }
        public double cenaBrutto { get; set; }
        public string dostawca { get; set; }
        public string uwagi { get; set; }

    }

    
}
