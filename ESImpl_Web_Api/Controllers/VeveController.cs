using System;
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
    /// Vertrieb und Verkauf Schnittstelle
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [RoutePrefix("veve")]
    public class VeveController : ApiController
    {
        readonly IVeveProvider _context;
        /// <summary>
        /// Vertrieb und Verkauf Schnittstelle
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
        /// Returns the customer by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customer/{customerId:int}")]
        public IEnumerable<CustomerModel> GetCustomersById(int customerId)
        {
            return this._context.GetCustomersById(customerId);
        }
        /// <summary>
        /// Returns all single items of an order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orderitems/{orderId:int}")]
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
        /// Returns all orders by a specifique Status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order/status/{statusId:int}")]
        public IEnumerable<CustomerOrderModel> GetCustomerOrdersByStatus(int statusId)
        {
            return this._context.GetCustomerOrdersByStatus(statusId);
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
        [Route("customer/{customerId:int}/orders")]
        public IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId)
        {
            return this._context.GetOrdersOfCustomer(customerId);
        }
        /// <summary>
        /// Create new customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("customer")]
        public CustomerModel CreateCustomer([FromBody] CustomerModel data)
        {
            return this._context.CreateCustomer(data);
        }
        /// <summary>
        /// Create new customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("order")]
        public CustomerOrderModel CreateCustOrder([FromBody] CustomerOrderFormModel data)
        {
            return this._context.CreateCustOrder(data);
        }
        /// <summary>
        /// Create new customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("orderitems")]
        public OrderItemsModel CreateOrderItem([FromBody] OrderItemsModel data)
        {
            return this._context.CreateOrderItem(data);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order/{orderId:int}")]
        public IEnumerable<CustomerOrderModel> GetOrderById(int orderId)
        {
            return this._context.GetOrderById(orderId);
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
