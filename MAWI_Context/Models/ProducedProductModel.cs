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
        public int OrderId { get; set; }
        public Nullable<int> Amount { get; set; }

        public virtual ICollection<CollectionOrderModel> CollectionOrder { get; set; }
    }
}
