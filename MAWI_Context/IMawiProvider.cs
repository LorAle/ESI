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
        IEnumerable<MaterialModel> GetMaterial();
        MaterialModel CreateMaterial(MaterialFormModel data);
        IEnumerable<QualityModel> GetQuality();
        QualityModel CreatQuality(QualityFormModel data);
        IEnumerable<QualityModel> GetQualityForMaterial(int materialId);
        IEnumerable<ProducedProductModel> GetProducedProduct();
        IEnumerable<ProducedProductModel> GetProducedProductById(int producedProductId);
        bool UpdateMaterial(int id, MaterialFormModel data);
        bool SupplyMaterial(String type, int amount);
        bool CollectMaterial(int amount, int? materialId, int? producedProductId, int? customerOrderId);

    }
}
