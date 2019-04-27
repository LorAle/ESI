using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEVE_Context.Models;

namespace VEVE_Context
{
    public class VeveProvider : IVeveProvider
    {
        private readonly VEVEEntities _context;
        public VeveProvider(VEVEEntities context)
        {
            _context = context;
        }
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _context.CUSTOMERS.Select(x => new CustomerModel
            {
                BUSINESSPARTNER = x.BUSINESSPARTNER,
                CITY = x.CITY,
                COUNTRY = x.COUNTRY,
                CUSTID = x.CUSTID,
                LASTNAME = x.LASTNAME,
                POSTCODE = x.POSTCODE,
                PRENAME = x.PRENAME,
                STREET = x.STREET
            }).ToList();
        }
    }
}
