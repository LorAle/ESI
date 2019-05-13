﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VEVE_Context;
using VEVE_Context.Models;

namespace ESImpl_Web_Api.Controllers
{
    /// <summary>
    /// Vertrieb & Verkauf Schnittstelle
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [RoutePrefix("veve")]
    public class VeveController : ApiController
    {
        readonly IVeveProvider _context;
        /// <summary>
        /// Vertrieb & Verkauf Schnittstelle
        /// </summary>
        /// <returns></returns>
        public VeveController()
        {
            _context = new VeveProvider(new VEVEEntities());
        }

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customer")]
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return this._context.GetCustomers();
        }
        /// <summary>
        /// Returns all single itmes of an order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orderitems")]
        public IEnumerable<OrderItemsModel> GetItemsByOrder(int orderId)
        {
            return this._context.GetItemsByOrder(orderId);
        }

        /// <summary>
        /// Returns all customer orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order")]
        public IEnumerable<CustomerOrderModel> GetCustomerOrders()
        {
            return this._context.GetCustomerOrders();
        }
        /// <summary>
        /// Returns all new customer orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order/new")]
        public IEnumerable<CustomerOrderModel> GetNewCustomerOrders()
        {
            return this._context.GetNewCustomerOrders();
        }
        /// <summary>
        /// Returns all approved customer orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order/done")]
        public IEnumerable<CustomerOrderModel> GetDoneCustomerOrders()
        {
            return this._context.GetDoneCustomerOrders();
        }

        /// <summary>
        /// Deletes an customer order
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("order/{orderId:int}")]
        public IEnumerable<CustomerOrderModel> DeleteCustomerOrders(int orderId)
        {
            return this._context.DeleteCustomerOrders(orderId);
        }
        /// <summary>
        /// Returns all orders of a certain customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customer/{customerId:int}")]
        public IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId)
        {
            return this._context.GetOrdersOfCustomer(customerId);
        }

        /// <summary>
        /// Updates the status of a certain order
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("order/{orderId:int}/{statusId:int}")]
        public IEnumerable<CustomerOrderModel> SetOrderStatus(int orderId, int statusId)
        {
            return this._context.SetOrderStatus(orderId,statusId);
        }
    }
}
