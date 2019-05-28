using MAWI_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAWI_Context
{
    public interface IMawiProvider
    {
        IEnumerable<SupplierModel> GetSuppliers();
        IEnumerable<String> GetSupplierNames();
        IEnumerable<SupplierModel> GetSupplierById(int supplierId);
        IEnumerable<MaterialModel> GetMaterial();
        IEnumerable<MaterialModel> GetMaterialById(int materialId);
        MaterialModel CreateMaterial(MaterialFormModel data);
        IEnumerable<ProducedProductModel> GetProducedProduct();
        IEnumerable<ProducedProductModel> GetProducedProductByCustId(int customerOrderId);
        IEnumerable<ProducedProductModel> GetProducedProductByProductionId(int productionId);
        bool UpdateMaterial(int id, MaterialFormModel data);
        bool DeleteMaterial(int materialId);
        bool SupplyMaterial(String type, int amount);
        bool CollectMaterial(int amount, int? materialId, int? producedProductId, int? customerOrderId);
        IEnumerable<QualityModel> GetQualitytById(int stockId);
        Stock CreateStockAndQuality(StockFormModel data);
        IEnumerable<SupplierModel> CreateSupplier(SupplierFormModel data);
        IEnumerable<CollectionOrderModel> GetCollectionOrders();
        IEnumerable<CollectionOrderModel> GetCollectionOrdersByState(String state);
        CollectionOrder CreateCollectionOrder(CollectionOrderFormModel data);
        bool UpdateCollectionOrder(int collectionOrderId);

    }
}
