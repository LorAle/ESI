using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEVE_Context.Models
{
    public class CustomerOrderModel
    {
        public int CUSTORDERID { get; set; }
        public int CUSTID { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public Nullable<int> STATUS { get; set; }

    }
}
