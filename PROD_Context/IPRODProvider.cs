using PROD_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROD_Context
{
    public interface IProdProvider
    {
        IEnumerable<ProductionOrderModel> GetProductionOrders();
    }
}
