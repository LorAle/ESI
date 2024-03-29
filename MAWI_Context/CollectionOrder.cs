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
    
    public partial class CollectionOrder
    {
        public CollectionOrder()
        {
            this.ProducedProduct = new HashSet<ProducedProduct>();
        }
    
        public int CollectionId { get; set; }
        public Nullable<int> StockId { get; set; }
        public Nullable<int> ProductionId { get; set; }
        public Nullable<int> CustOrderId { get; set; }
        public Nullable<int> Amount { get; set; }
        public string State { get; set; }
        public string OrderType { get; set; }
    
        public virtual Stock Stock { get; set; }
        public virtual ICollection<ProducedProduct> ProducedProduct { get; set; }
    }
}
