﻿using PROD_Context;
using PROD_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESImpl_Web_Api.Controllers
{
    /// <summary>
    /// Prodcution Interface
    /// </summary>
    [Authorize]
    [RoutePrefix("prod")]
    public class ProdController : ApiController
    {
        readonly IProdProvider _context;
        /// <summary>
        /// Initialize DB-Context
        /// </summary>
        public ProdController()
        {
            _context = new ProdProvider(new PRODEntities());
        }

        /// <summary>
        /// Returns all production orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ProductionOrderModel> GetProductionOrders(Nullable<int> statusId=null)
        {
            return this._context.GetProductionOrders(statusId);
        }

        /// <summary>
        /// Return the order
        /// </summary>
        /// <param name="orderId">The Id of the requested order</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderId:int}")]
        public ProductionOrderModel GetProductionOrder(int orderId)
        {
            return this._context.GetProductionOrder(orderId);
        }

        /// <summary>
        /// Creates a new production order entry and return the object with the generated id
        /// </summary>
        /// <param name="data">The Data of the new order</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public ProductionOrderModel CreateProductionOrder([FromBody] ProductionOrderFormModel data)
        {
            return this._context.CreateProductionOrder(data);
        }


        /// <summary>
        /// Updates the entry of the order
        /// </summary>
        /// <param name="orderId">The Id of the order</param>
        /// <param name="data">The new data for the order</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{orderId:int}")]
        public bool UpdateProductionOrder(int orderId, [FromBody] ProductionOrderFormModel data)
        {
            return this._context.UpdateProductionOrder(orderId, data);
        }


        /// <summary>
        /// Deletes the entry of the given order id
        /// </summary>
        /// <param name="orderId">The id of the order</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{orderId:int}")]
        public bool DeleteProductionOrder(int orderId)
        {
            return this._context.DeleteProductionOrder(orderId);
        }

        /// <summary>
        /// Returns all production order status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("status")]
        public IEnumerable<ProductionOrderStatusModel> GetProductionOrderStatus()
        {
            return this._context.GetProductionOrderStatus();
        }

        /// <summary>
        /// Updates all ´InPlanning' orders with the new sorting number
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("order")]
        public IEnumerable<ProductionOrderModel> SortProductionOrders()
        {
            return this._context.SortProductionOrders();
        }
    }
}
