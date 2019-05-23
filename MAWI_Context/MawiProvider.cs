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

        public IEnumerable<String> GetSupplierNames()
        {
            return _context.Supplier.Select(x => x.Name).ToList();
        }

        public IEnumerable<MaterialModel> GetMaterial()
        {
            return _context.Material.Select(x => new MaterialModel
            {
                MaterialId = x.MaterialId,
                SupplierId = x.SupplierId,
                Name = x.Name,
                DeliveryDate = x.DeliveryDate,
                Description = x.Description,
                MinStock = x.MinStock,
                PackagingSize = x.PackagingSize,
                Unit = x.Unit,
                Price = x.Price
            }).ToList();
        }

        public bool UpdateMaterial(int id, MaterialFormModel data)
        {
            Material materialFromDB = _context.Material.Find(id);
            if (materialFromDB == null)
            {
                return false;
            }
            data.MaterialId = id;

            _context.Entry(materialFromDB).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMaterial(int materialId)
        {
            Material materialFromDB = _context.Material.Find(materialId);
            if (materialFromDB == null)
            {
                return false;
            }
            _context.Material.Remove(materialFromDB);
            _context.SaveChanges();
            return true;
        }

        public bool SupplyMaterial(String type, int amount)
        {
            if (type != null && amount > 0)
            {
                // auf die If/Else kann verzichtet werden, wenn man sich darauf einigt,
                // dass immer type immer auf Wert in Feld Name matched.
                //  if (type == "Shirt")
                //{
                var materialFromDB = _context.Material.Where(x => (x.Name.Contains(type) && x.MinStock > amount));
                    if (materialFromDB != null)
                    {
                        // holt sich ersten Eintrag auf den Bedingung zutrifft
                        if (materialFromDB.First() != null)
                        {
                        var firstMaterial = materialFromDB.First();
                        // Berechnet neue Bestand
                        int newStock = firstMaterial.MinStock.Value - amount;
                            firstMaterial.MinStock = newStock;

                            // Eintrag in DB updaten
                            _context.Entry(firstMaterial).CurrentValues.SetValues(newStock);
                            _context.SaveChanges();
                            return true;
                        }
                    }
            }

            return false;
        }

        public bool CollectMaterial(int amount, int? materialId, int? producedProductId, int? customerOrderId)
        {
            // wenn materialId nicht befuellt ist, dann handelt es sich um ein Fertigprodukt
            if ((materialId == null || materialId == 0) && producedProductId != null && customerOrderId != null)
            {
                ProducedProduct newProdProduct = new ProducedProduct();
                newProdProduct.Amount = amount;
                newProdProduct.OrderId = customerOrderId.GetValueOrDefault();
                newProdProduct.ProducedProductId = producedProductId.GetValueOrDefault();
                _context.ProducedProduct.Add(newProdProduct);
                _context.SaveChanges();
                return true;
                
            }
            // wenn wieder Farbe eingelagert werden muss
            else
            {
                materialId = materialId.GetValueOrDefault();
                // Material updaten
                Material materialFromDB = _context.Material.Find(materialId);
                if (materialFromDB == null)
                {
                    // Create koennte man nur machen, wenn auch die SupplierId mit uebergeben wird
                    return false;
                }
                materialFromDB.MinStock = materialFromDB.MinStock.Value + amount;

                _context.Entry(materialFromDB).CurrentValues.SetValues(amount);
                _context.SaveChanges();
                return true;
            }
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
                Name = newMaterial.Name,
                DeliveryDate = newMaterial.DeliveryDate,
                Description = newMaterial.Description,
                MinStock = newMaterial.MinStock,
                PackagingSize = newMaterial.PackagingSize,
                Unit = newMaterial.Unit,
                Price = newMaterial.Price,
                Supplier = newMaterial.Supplier
            };
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

        public IEnumerable<ProducedProductModel> GetProducedProductByCustId(int custOrderId)
        {

            var producedProductFromDB = _context.ProducedProduct.Where(x => x.OrderId == custOrderId);
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

        public IEnumerable<QualityModel> GetQualitytById(int stockId)
        {
            var stockAndQualityFromDB = _context.Stock.Where(x => x.StockId == stockId);
            if (stockAndQualityFromDB != null)
            {
                return stockAndQualityFromDB.Select(x => new QualityModel
                {
                    MaterialId = x.MaterialId,
                    Whiteness = x.Whiteness,
                    Absorbency = x.Absorbency,
                    Viscosity = x.Viscosity,
                    Ppml = x.Ppml,
                    DeltaE = x.DeltaE
                }).ToList();
            }
            return new List<QualityModel>();
        }
    }
}
