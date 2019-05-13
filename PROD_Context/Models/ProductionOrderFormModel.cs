using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROD_Context.Models
{
    public class ProductionOrderFormModel
    {
        public int CustomerOrderId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Color { get; set; }
        public string Motiv { get; set; }
        public int Amount { get; set; }
        public Nullable<int> OrderItem { get; set; }
        public int ProductionStatusId { get; set; }
        public Nullable<int> OrderPosition { get; set; }
    }
}
