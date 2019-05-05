using PROD_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROD_Context
{
    public class ProdProvider : IProdProvider
    {
        private readonly PRODEntities _context;
        public ProdProvider(PRODEntities context)
        {
            _context = context;
        }
        public IEnumerable<ProductionOrderModel> GetProductionOrders()
        {
            return _context.ProductionOrder.Select(x => new ProductionOrderModel
            {
                ProductionOrdercol = x.ProductionOrdercol
            }).ToList();
        }
    }
}
