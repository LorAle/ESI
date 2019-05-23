using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class CollectionOrderFormModel
    {

        // public int CollectionId { get; set; }
        public Nullable<int> StockId { get; set; }
        // public Nullable<int> ProducedProductId { get; set; }
        public Nullable<int> CustOrderId { get; set; }
        public int Amount { get; set; }


    }
}
