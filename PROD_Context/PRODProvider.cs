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
                Id = x.Id,
                Amount = x.Amount,
                Color = x.Color,
                CustomerOrderId = x.CustomerOrderId,
                DeliveryDate = x.DeliveryDate,
                Motiv = x.Motiv,
                OrderDate = x.OrderDate,
                OrderItem = x.OrderItem,
                OrderPosition = x.OrderPosition,
                ProductionStatusId = x.ProductionStatusId
            }).ToList();
        }

        public ProductionOrderModel CreateProductionOrder(ProductionOrderFormModel data)
        {
            ProductionOrder newOrder = new ProductionOrder();
            _context.ProductionOrder.Add(newOrder);
            _context.Entry(newOrder).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return new ProductionOrderModel
            {
                Id = newOrder.Id,
                Amount = newOrder.Amount,
                Color = newOrder.Color,
                CustomerOrderId = newOrder.CustomerOrderId,
                DeliveryDate = newOrder.DeliveryDate,
                Motiv = newOrder.Motiv,
                OrderDate = newOrder.OrderDate,
                OrderItem = newOrder.OrderItem,
                OrderPosition = newOrder.OrderPosition,
                ProductionStatusId = newOrder.ProductionStatusId
            };
        }

        public bool UpdateProductionOrder(int orderId, ProductionOrderFormModel data)
        {
            ProductionOrder orderFromDb = _context.ProductionOrder.Find(orderId);
            if (orderFromDb == null)
            {
                return false;
            }
            _context.Entry(orderFromDb).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteProductionOrder(int orderId)
        {
            ProductionOrder orderFromDb = _context.ProductionOrder.Find(orderId);
            if (orderFromDb == null)
            {
                return false;
            }
            _context.ProductionOrder.Remove(orderFromDb);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ProductionOrderStatusModel> GetProductionOrderStatus()
        {
            return _context.ProductionStatus.Select(x => new ProductionOrderStatusModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }

    }
}
