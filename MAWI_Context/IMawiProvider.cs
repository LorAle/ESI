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
        IEnumerable<MaterialModel> GetMaterial();
        MaterialModel CreateMaterial(MaterialFormModel data);
        IEnumerable<QualityModel> GetQuality();
        QualityModel CreatQuality(QualityFormModel data);
        IEnumerable<QualityModel> GetQualityForMaterial(int materialId);
        IEnumerable<ProducedProductModel> GetProducedProduct();
        IEnumerable<ProducedProductModel> GetProducedProductById(int producedProductId);
        MaterialOrderModel CreateMaterialOrderModel(MaterialOrderModel data);

    }
}
