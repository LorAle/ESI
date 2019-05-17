using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAWI_Context.Models;

namespace MAWI_Context
{
    public class MawiProvider : IMawiProvider
    {
        private readonly MAWIEntities _context;
        public MawiProvider(MAWIEntities context)
        {
            _context = context;
        }

        public IEnumerable<SupplierModel> GetSuppliers()
        {
            return _context.Supplier.Select(x => new SupplierModel
            {
                SupplierId = x.SupplierId,
                Name = x.Name,
                Address = x.Address,
                PLZ = x.PLZ,
                City = x.City,
                Email = x.Email,
                Contactperson = x.Contactperson,
                Phone = x.Phone
            }).ToList();
        }

        public IEnumerable<MaterialModel> GetMaterial()
        {
            return _context.Material.Select(x => new MaterialModel
            {
                MaterialId = x.MaterialId,
                SupplierId = x.SupplierId,
                DeliveryDate = x.DeliveryDate,
                Description = x.Description,
                Stock = x.Stock,
                Unit = x.Unit,
                Price = x.Price,
                Supplier = x.Supplier,
                Quality = x.Quality
            }).ToList();
        }


        public MaterialModel CreateMaterial(MaterialFormModel data)
        {
            Material newMaterial = new Material();
            _context.Material.Add(newMaterial);
            _context.Entry(newMaterial).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return new MaterialModel
            {
                MaterialId = newMaterial.MaterialId,
                SupplierId = newMaterial.SupplierId,
                DeliveryDate = newMaterial.DeliveryDate,
                Description = newMaterial.Description,
                Stock = newMaterial.Stock,
                Unit = newMaterial.Unit,
                Price = newMaterial.Price,
                Supplier = newMaterial.Supplier,
                Quality = newMaterial.Quality
            };
        }


        public IEnumerable<QualityModel> GetQuality()
        {
            return _context.Quality.Select(x => new QualityModel
            {
                QualityId = x.QualityId,
                MaterialId = x.MaterialId,
                Whiteness = x.Whiteness,
                Absorbency = x.Absorbency,
                Viscosity = x.Viscosity,
                Ppml = x.Ppml,
                DeltaE = x.DeltaE,
                Amount = x.Amount
            }).ToList();
        }

        public QualityModel CreatQuality(QualityFormModel data)
        {
            Quality newQuality = new Quality();
            _context.Quality.Add(newQuality);
            _context.Entry(newQuality).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return new QualityModel
            {
                MaterialId = newQuality.MaterialId,
                QualityId = newQuality.QualityId,
                Whiteness = newQuality.Whiteness,
                Absorbency = newQuality.Absorbency,
                Viscosity = newQuality.Viscosity,
                Ppml = newQuality.Ppml,
                DeltaE = newQuality.DeltaE,
                Amount = newQuality.Amount
            };
        }

        public IEnumerable<QualityModel> GetQualityForMaterial(int materialId)
        {
                var qualityFromDB = _context.Quality.Where(x => x.MaterialId == materialId);
                if (qualityFromDB != null)
                {
                    return qualityFromDB.Select(x => new QualityModel
                    {
                        QualityId = x.QualityId,
                        MaterialId = x.MaterialId,
                        Whiteness = x.Whiteness,
                        Absorbency = x.Absorbency,
                        Viscosity = x.Viscosity,
                        Ppml = x.Ppml,
                        DeltaE = x.DeltaE,
                        Amount = x.Amount
                    }).ToList();
                }
            return new List<QualityModel>();
        }

        public IEnumerable<ProducedProductModel> GetProducedProduct()
        {
            return _context.ProducedProduct.Select(x => new ProducedProductModel
            {
                ProducedProductId = x.ProducedProductId,
                OrderId = x.OrderId,
                Amount = x.Amount
            }
                ).ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<ProducedProductModel> GetProducedProductById(int producedProductId)
        {

            var producedProductFromDB = _context.ProducedProduct.Where(x => x.ProducedProductId == producedProductId);
            if (producedProductFromDB != null)
            {
                return producedProductFromDB.Select(x => new ProducedProductModel
                {
                    ProducedProductId = x.ProducedProductId,
                    OrderId = x.OrderId,
                    Amount = x.Amount
                }).ToList();
            }
            return new List<ProducedProductModel>();
        }

        // Schnittstelle Materialbereitstellen
        public MaterialOrderModel CreateMaterialOrderModel(MaterialOrderModel data)
        {
            MaterialOrderModel newQuality = new MaterialOrderModel();
            return new MaterialOrderModel
            {
            };
        }
    }
}
