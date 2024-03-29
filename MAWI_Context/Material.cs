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
    
    public partial class Material
    {
        public Material()
        {
            this.Stock = new HashSet<Stock>();
        }
    
        public int MaterialId { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> MinStock { get; set; }
        public Nullable<int> PackagingSize { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
