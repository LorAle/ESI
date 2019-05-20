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
        /// gibt alle Lieferantennamen zurueck
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("suppliernames")]
        public IEnumerable<String> GetSupplierNames()
        {
            return this._context.GetSupplierNames();
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

        /// <summary>
        /// Material updaten, z.B. wenn Produktion Material benoetigt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("material/{id:int}")]
        public bool UpdateMaterial(int id, [FromBody] MaterialFormModel data)
        {
            return this._context.UpdateMaterial(id, data);
        }

        /// <summary>
        /// Material updaten, z.B. wenn Produktion Material benoetigt
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order/supply")]
        public bool SupplyMaterial(String  type, int amount)
        {
            return this._context.SupplyMaterial(type, amount);
        }

        /// <summary>
        /// wird benoetigt um Qualitaetswerte anzulegen
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("quality")]
        public QualityModel CreateQuality([FromBody] QualityFormModel data)
        {
            return this._context.CreatQuality(data);
        }
    }
}
