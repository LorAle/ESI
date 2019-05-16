using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class MaterialOrderModel
    {
        public string Flag { get; set; }
        public string Typ { get; set; }
        public Nullable<int> Material { get; set; }
        public int Amount { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> CustomerOrderId { get; set; }
    }
}
