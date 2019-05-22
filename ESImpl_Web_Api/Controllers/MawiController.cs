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
        /// gibt die Fertigprodukte anhand eines Kundenauftrags zurueck
        /// </summary>
        /// <param name="customerOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("producedProduct/{customerOrderId:int}")]
        public IEnumerable<ProducedProductModel> GetProducedProductById(int customerOrderId)
        {
            return this._context.GetProducedProductByCustId(customerOrderId);
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
        /// Material anlegen
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
        /// Material ueber MaterialId updaten
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
        /// SST zu Produktion - Material bereitstellen
        /// Fuehrt update auf DB aus
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
        /// SST zu Produktion Material einlagern
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="amount"></param>
        /// <param name="producedProductId"></param>
        /// <param name="customerOrderId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("order/collect")]
        public bool CollectMaterial(int amount, int? materialId = null, int? producedProductId = null, int? customerOrderId = null)
        {
            return this._context.CollectMaterial(amount, materialId, producedProductId, customerOrderId);
        }

        /// <summary>
        /// Qualitaetswerte anlegen
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
