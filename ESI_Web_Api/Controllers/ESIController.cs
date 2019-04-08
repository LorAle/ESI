using ESI_Context;
using ESI_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESI_Web_Api.Controllers
{
    [Authorize]
    [RoutePrefix("product")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ESIController : ApiController
    {
        IProductProvider _context;
        public ESIController()
        {
            _context = new ProductProvider(new ESI_Entities());
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ProductModel> GetProducts()
        {
            return this._context.GetProducts();
        }




    }
}
