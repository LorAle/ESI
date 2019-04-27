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
        [Route("getCustomers")]
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return this._context.GetCustomers();
        }
    }
}
