using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> PLZ { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Contactperson { get; set; }
        public Nullable<int> Phone { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
