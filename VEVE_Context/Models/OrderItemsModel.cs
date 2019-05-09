using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEVE_Context.Models
{
    class OrderItemsModel
    {
        public int ITEMID { get; set; }
        public int CUSTORDERID { get; set; }
        public int ARTICLENUMBER { get; set; }
        public string COLORCODE { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public string COLORNAME { get; set; }
        public sbyte HASPRINT { get; set; }
        public Nullable<int> PRINTNUMBER { get; set; }
    }
}
