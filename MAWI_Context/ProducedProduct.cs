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
    
    public partial class ProducedProduct
    {
        public int ProducedProductId { get; set; }
        public int ProductionId { get; set; }
        public int CustOrderId { get; set; }
        public Nullable<int> CollectionOrderId { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual CollectionOrder CollectionOrder { get; set; }
    }
}
