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

        ProductionOrderModel GetProductionOrder(int orderId);
        ProductionOrderModel CreateProductionOrder(ProductionOrderFormModel data);
        IEnumerable<ProductionOrderStatusModel> GetProductionOrderStatus();

        bool UpdateProductionOrder(int orderId, ProductionOrderFormModel data);

        bool DeleteProductionOrder(int orderId);

        IEnumerable<ProductionOrderModel> SortProductionOrders();
    }
}
