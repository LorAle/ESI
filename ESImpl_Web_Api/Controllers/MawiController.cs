using MAWI_Context;
using MAWI_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESImpl_Web_Api.Controllers
{
    [Authorize]
    [RoutePrefix("mawi")]
    public class MawiController : ApiController
    {
        readonly IMawiProvider _context;
        public MawiController()
        {
            _context = new MawiProvider(new MAWIEntities());
        }

        /// <summary>
        /// gibt alle Lieferanten zurueck
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("suppliers")]
        public IEnumerable<SupplierModel> GetSuppliers()
        {
            return this._context.GetSuppliers();
        }

        /// <summary>
        /// gibt alle Fertigprodukte zurueck
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("producedProduct")]
        public IEnumerable<ProducedProductModel> GetProducedProduct()
        {
            return this._context.GetProducedProduct();
        }

        /// <summary>
        /// liefert die Qualitaetswerte fuer ein Material
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("producedProduct/{producedProductId:int}")]
        public IEnumerable<ProducedProductModel> GetProducedProductById(int producedProductId)
        {
            return this._context.GetProducedProductById(producedProductId);
        }

        /// <summary>
        /// gibt alle Materialien zurueck
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<MaterialModel> GetMaterials()
        {
            return this._context.GetMaterial();
        }

        /// <summary>
        /// liefert die Qualitaetswerte fuer ein Material
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("material/{materialId:int}")]
        public IEnumerable<QualityModel> GetQualityForMaterial(int materialId)
        {
            return this._context.GetQualityForMaterial(materialId);
        }

        /// <summary>
        /// wird benoetigt um Material anzulegen
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public MaterialModel CreateMaterial([FromBody] MaterialFormModel data)
        {
            return this._context.CreateMaterial(data);
        }

    }
}
