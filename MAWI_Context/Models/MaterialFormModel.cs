using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class MaterialFormModel
    {
        public int MaterialId { get; set; }
        public int SupplierId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }

    }
}
