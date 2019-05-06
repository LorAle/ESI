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
        [Route("customer/{customerId:int}")]
        public IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId)
        {
            return this._context.GetOrdersOfCustomer(customerId);
        }
    }
}
