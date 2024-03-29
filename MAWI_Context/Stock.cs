//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MAWI_Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public Stock()
        {
            this.CollectionOrder = new HashSet<CollectionOrder>();
        }
    
        public int StockId { get; set; }
        public int MaterialId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> Whiteness { get; set; }
        public Nullable<decimal> Absorbency { get; set; }
        public Nullable<decimal> Viscosity { get; set; }
        public Nullable<int> Ppml { get; set; }
        public Nullable<decimal> DeltaE { get; set; }
    
        public virtual ICollection<CollectionOrder> CollectionOrder { get; set; }
        public virtual Material Material { get; set; }
    }
}
