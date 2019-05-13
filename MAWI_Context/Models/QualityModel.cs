using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class QualityModel
    {
        public int QualityId { get; set; }
        public int MaterialId { get; set; }
        public Nullable<int> Whiteness { get; set; }
        public Nullable<decimal> Absorbency { get; set; }
        public Nullable<int> Viscosity { get; set; }
        public Nullable<int> Ppml { get; set; }
        public Nullable<decimal> DeltaE { get; set; }
        public Nullable<int> Amount { get; set; }

        public virtual Material Material { get; set; }
    }
}
