using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESI_Context.Models;

namespace ESI_Context
{
    public class ProductProvider : IProductProvider
    {
        private readonly ESI_Entities _context;
        public ProductProvider(ESI_Entities context)
        {
            _context = context;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            return _context.Product.Select(x => new ProductModel {
                Name = x.Name
            }).ToList();
        }
    }
}
