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

   
    }
}
