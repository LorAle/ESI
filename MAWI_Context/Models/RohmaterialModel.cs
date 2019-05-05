using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class RohmaterialModel : MaterialModel
    {
        public float viskositaet { get; set; }
        public float deltaE { get; set; }
        public float saugfaehig { get; set; }
        public int ppml { get; set; }
        public int weissgrad { get; set; }
    }
}
