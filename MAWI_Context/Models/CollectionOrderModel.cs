using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class CollectionOrderModel
    {

        public int CollectionId { get; set; }
        public Nullable<int> StockId { get; set; }
        public Nullable<int> ProductionId { get; set; }
        public Nullable<int> CustOrderId { get; set; }
        public Nullable<int> Amount { get; set; }
        public string State { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<ProducedProduct> ProducedProduct { get; set; }

    }
}
