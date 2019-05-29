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

        public IEnumerable<SupplierModel> CreateSupplier(SupplierFormModel data)
        {
            Supplier newSupplier = new Supplier();
            _context.Supplier.Add(newSupplier);
            _context.Entry(newSupplier).CurrentValues.SetValues(data);
            _context.SaveChanges();
            yield return new SupplierModel
            {
                SupplierId = newSupplier.SupplierId,
                Name = newSupplier.Name,
                Address = newSupplier.Address,
                PLZ = newSupplier.PLZ,
                City = newSupplier.City,
                Email = newSupplier.Email,
                Contactperson = newSupplier.Contactperson,
                Phone = newSupplier.Phone
            };
        }
        public IEnumerable<SupplierModel> GetSupplierById(int supplierId)
        {

            var supplierFromDB = _context.Supplier.Where(x => x.SupplierId == supplierId);
            if (supplierFromDB != null)
            {
                return supplierFromDB.Select(x => new SupplierModel
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
            return new List<SupplierModel>();
        }

        public IEnumerable<MaterialModel> GetMaterialById(int materialId)
        {

            var materialFromDB = _context.Material.Where(x => x.MaterialId == materialId);
            if (materialFromDB != null)
            {
                return materialFromDB.Select(x => new MaterialModel
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
            return new List<MaterialModel>();
        }

        public IEnumerable<MaterialModel> GetMaterialBySupplierId(int supplierId)
        {

            var materialFromDB = _context.Material.Where(x => x.SupplierId == supplierId);
            if (materialFromDB != null)
            {
                return materialFromDB.Select(x => new MaterialModel
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
            return new List<MaterialModel>();
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

        public bool CollectMaterial(int amount, int? materialId, int? productionId, int? customerOrderId)
        {
            // wenn materialId nicht befuellt ist, dann handelt es sich um ein Fertigprodukt
            if ((materialId == null || materialId == 0) && productionId != null && customerOrderId != null)
            {
                ProducedProduct newProdProduct = new ProducedProduct();
                newProdProduct.Amount = amount;
                newProdProduct.CustOrderId = customerOrderId.GetValueOrDefault();
                newProdProduct.ProductionId = productionId.GetValueOrDefault();
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
                ProductionId = x.ProductionId,
                CustOrderId = x.CustOrderId,
                CollectionOrderId = x.CollectionOrderId,
                Amount = x.Amount
            }).ToList();
        }

        public IEnumerable<ProducedProductModel> GetProducedProductByCustId(int custOrderId)
        {

            var producedProductFromDB = _context.ProducedProduct.Where(x => x.CustOrderId == custOrderId);
            if (producedProductFromDB != null)
            {
                return producedProductFromDB.Select(x => new ProducedProductModel
                {
                    ProducedProductId = x.ProducedProductId,
                    CustOrderId = x.CustOrderId,
                    CollectionOrderId = x.CollectionOrderId,
                    Amount = x.Amount
                }).ToList();
            }
            return new List<ProducedProductModel>();
        }

        public IEnumerable<ProducedProductModel> GetProducedProductByProductionId(int productionId)
        {

            var producedProductFromDB = _context.ProducedProduct.Where(x => x.ProductionId == productionId);
            if (producedProductFromDB != null)
            {
                return producedProductFromDB.Select(x => new ProducedProductModel
                {
                    ProducedProductId = x.ProducedProductId,
                    ProductionId = x.ProductionId,
                    CustOrderId = x.CustOrderId,
                    CollectionOrderId = x.CollectionOrderId,
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

        public Stock CreateStockAndQuality(StockFormModel data)
        {
            Stock newStock = new Stock();
            _context.Stock.Add(newStock);
            _context.Entry(newStock).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return new Stock{
                MaterialId = newStock.MaterialId,
                Amount = newStock.Amount,
                Whiteness = newStock.Whiteness,
                Absorbency = newStock.Absorbency,
                Viscosity = newStock.Viscosity,
                Ppml = newStock.Ppml,
                DeltaE = newStock.DeltaE
            };
        }

        public IEnumerable<StockModel> GetStocks()
        {
            return _context.Stock.Select(x => new StockModel
            {
                StockId = x.StockId,
                MaterialId = x.MaterialId,
                Amount = x.Amount,
                Whiteness = x.Whiteness,
                Absorbency = x.Absorbency,
                Viscosity = x.Viscosity,
                Ppml = x.Ppml,
                DeltaE = x.DeltaE
            }).ToList();
        }

        public IEnumerable<CollectionOrderModel> GetCollectionOrders()
        {
            return _context.CollectionOrder.Select(x => new CollectionOrderModel
            {
                CollectionId = x.CollectionId,
                StockId  = x.StockId,
                ProductionId = x.ProductionId,
                CustOrderId = x.CustOrderId,
                Amount = x.Amount,
                State = x.State
            }).ToList();
        }

        public IEnumerable<CollectionOrderModel> GetCollectionOrdersByState(String state)
        {
            if(state == "New" || state == "Done")
            {
                var collectionOrderFromDB = _context.CollectionOrder.Where(x => x.State.Equals(state));
                if (collectionOrderFromDB != null)
                {
                    return collectionOrderFromDB.Select(x => new CollectionOrderModel
                    {
                        CollectionId = x.CollectionId,
                        StockId = x.StockId,
                        ProductionId = x.ProductionId,
                        CustOrderId = x.CustOrderId,
                        State = x.State
                    }).ToList();
                }
            }
            return new List<CollectionOrderModel>();
        }

        public CollectionOrder CreateCollectionOrder(CollectionOrderFormModel data)
        {
            bool valid = false;
            CollectionOrder newCollectionOrder = new CollectionOrder();
            newCollectionOrder.State = "New";
            // Falls Rohmaterial wieder eingelagert werden muss, muss geprueft werden ob es StockId existiert
            if (data.StockId != null || data.StockId != 0)
            {
                valid = _context.Stock.Any(x => x.StockId == data.StockId);
            }
            // wenn Fertigprodukt eingelagert werden soll, darf die Id nicht null sein
            if (data.CustOrderId != null || data.CustOrderId != 0)
            {
                valid = true;
            }
            if (valid)
            {
                _context.CollectionOrder.Add(newCollectionOrder);
                _context.Entry(newCollectionOrder).CurrentValues.SetValues(data);
                _context.SaveChanges();

                return new CollectionOrder
                {
                    StockId = newCollectionOrder.StockId,
                    ProductionId = newCollectionOrder.ProductionId,
                    CustOrderId = newCollectionOrder.CustOrderId,
                    Amount = newCollectionOrder.Amount,
                    State = newCollectionOrder.State
                };
            }
            return null;
        }

        public bool UpdateCollectionOrder(int collectionOrderId)
        {
            if (collectionOrderId == 0) return false;

            bool valid = false;

            CollectionOrder colOrder = _context.CollectionOrder.Find(collectionOrderId);
            var collectionOrderFromDB = _context.CollectionOrder.Where(x => x.CollectionId == collectionOrderId);
            if (colOrder != null)
            {
                var productionId = colOrder.ProductionId;
                var stockId = colOrder.StockId;
                if (productionId != null)
                {
                    valid = updateProducedProductFromCollectionOrder(colOrder, productionId);
                }
                if (stockId != null)
                {
                    valid = updateStockFromCollectionOrder(colOrder, stockId);
                }

                // wenn Stock-Tabelle oder Produced-Product-Tabelle geupdatet wurden, dann true
                if (valid)
                {
                    var state = colOrder.State = "Done";
                    // Speichert Aenderungen
                    _context.Entry(colOrder).CurrentValues.SetValues(state);
                    _context.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        private bool updateProducedProductFromCollectionOrder(CollectionOrder colOrder, int? productionId)
        {
            if (colOrder != null && productionId != null)
            {
                ProducedProduct newProducedProduct = new ProducedProduct
                {
                    ProductionId = productionId.GetValueOrDefault(),
                    CustOrderId = colOrder.CustOrderId.GetValueOrDefault(),
                    CollectionOrderId = colOrder.CollectionId,
                    Amount = colOrder.Amount.GetValueOrDefault()
                };
                _context.ProducedProduct.Add(newProducedProduct);
                //_context.Entry(newCollectionOrder).CurrentValues.SetValues(data);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        private bool updateStockFromCollectionOrder(CollectionOrder colOrder, int? stockId)
        {
            if (colOrder != null && stockId != null)
            {
                Stock stockFromDB = _context.Stock.Find(stockId);
                if (stockFromDB == null)
                {
                    return false;
                }
                // holt sich aktuellen Amount 
                var amount = colOrder.Amount.GetValueOrDefault();
                // erhoeht Amount um den neu zu eingelagerten Bestand
                var newAmount = stockFromDB.Amount = stockFromDB.Amount.GetValueOrDefault() + amount;
                // Speichert Aenderungen
                _context.Entry(stockFromDB).CurrentValues.SetValues(newAmount);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
