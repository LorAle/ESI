using PROD_Context;
using PROD_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESImpl_Web_Api.Controllers
{
    [Authorize]
    [RoutePrefix("prod")]
    public class ProdController : ApiController
    {
        readonly IProdProvider _context;
        public ProdController()
        {
            _context = new ProdProvider(new PRODEntities());
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ProductionOrderModel> GetProductionOrders()
        {
            return this._context.GetProductionOrders();
        }

        [HttpPost]
        [Route("")]
        public ProductionOrderModel CreateProductionOrder([FromBody] ProductionOrderFormModel data)
        {
            return this._context.CreateProductionOrder(data);
        }

        [HttpPut]
        [Route("{orderId:int}")]
        public bool UpdateProductionOrder(int orderId, [FromBody] ProductionOrderFormModel data)
        {
            return this._context.UpdateProductionOrder(orderId, data);
        }

        [HttpDelete]
        [Route("{orderId:int}")]
        public bool DeleteProductionOrder(int orderId)
        {
            return this._context.DeleteProductionOrder(orderId);
        }

        [HttpGet]
        [Route("status")]
        public IEnumerable<ProductionOrderStatusModel> GetProductionOrderStatis()
        {
            return this._context.GetProductionOrderStatus();
        }
    }
}
