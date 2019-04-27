using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEVE_Context.Models
{
    public class CustomerModel
    {
        public int CUSTID { get; set; }
        public string LASTNAME { get; set; }
        public string PRENAME { get; set; }
        public string STREET { get; set; }
        public string POSTCODE { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<sbyte> BUSINESSPARTNER { get; set; }
    }
}
