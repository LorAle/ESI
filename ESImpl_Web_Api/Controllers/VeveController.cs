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
    [Authorize]
    [RoutePrefix("veve")]
    public class VeveController : ApiController
    {
        readonly IVeveProvider _context;
        public VeveController()
        {
            _context = new VeveProvider(new VEVEEntities());
        }

        [HttpGet]
        [Route("customer")]
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return this._context.GetCustomers();
        }

        [HttpGet]
        [Route("order")]
        public IEnumerable<CustomerOrderModel> GetCustomerOrders()
        {
            return this._context.GetCustomerOrders();
        }
        [HttpGet]
        [Route("order/new")]
        public IEnumerable<CustomerOrderModel> GetNewCustomerOrders()
        {
            return this._context.GetNewCustomerOrders();
        }
        [HttpGet]
        [Route("order/done")]
        public IEnumerable<CustomerOrderModel> GetDoneCustomerOrders()
        {
            return this._context.GetDoneCustomerOrders();
        }
        [HttpDelete]
        [Route("order/{orderId:int}")]
        public IEnumerable<CustomerOrderModel> DeleteCustomerOrders(int orderId)
        {
            return this._context.DeleteCustomerOrders(orderId);
        }

        [HttpGet]
        [Route("customer/{customerId:int}")]
        public IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId)
        {
            return this._context.GetOrdersOfCustomer(customerId);
        }

        [HttpPut]
        [Route("order/{orderId:int}/{statusId:int}")]
        public IEnumerable<CustomerOrderModel> SetOrderStatus(int orderId, int statusId)
        {
            return this._context.SetOrderStatus(orderId,statusId);
        }
    }
}
