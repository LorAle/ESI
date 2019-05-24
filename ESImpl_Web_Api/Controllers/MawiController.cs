﻿using MAWI_Context;
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
        /// Lieferanten anlegen
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        [Route("supplier")]
        public IEnumerable<SupplierModel> CreateSupplier(SupplierFormModel data)
        {
            return this._context.CreateSupplier(data);
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
        /// gibt die Fertigprodukte anhand eines Fertigungsauftrags zurueck
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("producedProductProduction/{productionId:int}")]
        public IEnumerable<ProducedProductModel> GetProducedProductByProductionId(int productionId)
        {
            return this._context.GetProducedProductByProductionId(productionId);
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
        /// entfernt Material aus DB
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("material/{materialId:int}")]
        public bool DeleteMaterial(int materialId)
        {
            return this._context.DeleteMaterial(materialId);
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
        /// liefert Qualitaetswerte fuer ein Material zurueck
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("quality/{stockId:int}")]
        public IEnumerable<QualityModel> GetQualitytById(int stockId)
        {
            return this._context.GetQualitytById(stockId);
        }

        /// <summary>
        /// Neues Rohmaterial in Bestandstabelle anlegen
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("stock")]
        public Stock CreateStockAndQuality(StockFormModel data)
        {
            return this._context.CreateStockAndQuality(data);
        }

        /// <summary>
        /// gibt alle Abholauftrage zurueck
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("collectionOrder")]
        public IEnumerable<CollectionOrder> GetCollectionOrders()
        {
            return this._context.GetCollectionOrders();
        }

        /// <summary>
        /// Abholauftrag anlegen
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("collectionOrder")]
        public CollectionOrder CreateCollectionOrder(CollectionOrderFormModel data)
        {
            return this._context.CreateCollectionOrder(data);
        }

        /// <summary>
        /// Um Abholauftrag einzulagern
        /// </summary>
        /// <param name="collectionOrderId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("collectionOrder/{collectionOrderId:int}")]
        public bool UpdateCollectionOrder(int collectionOrderId)
        {
            return this._context.UpdateCollectionOrder(collectionOrderId);
        }

    }
}
