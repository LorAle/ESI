using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class ProducedProductModel
    {
        public int ProducedProductId { get; set; }
        public int ProductionId { get; set; }
        public int CustOrderId { get; set; }
        public Nullable<int> CollectionOrderId { get; set; }
        public Nullable<int> Amount { get; set; }

        public virtual CollectionOrder CollectionOrder { get; set; }
    }
}
