﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context.Models
{
    public class QualityModel
    {

        public int MaterialId { get; set; }
        public Nullable<int> Whiteness { get; set; }
        public Nullable<decimal> Absorbency { get; set; }
        public Nullable<decimal> Viscosity { get; set; }
        public Nullable<int> Ppml { get; set; }
        public Nullable<decimal> DeltaE { get; set; }

    }
}
