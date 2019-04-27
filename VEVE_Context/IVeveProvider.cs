using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEVE_Context.Models;

namespace VEVE_Context
{
    public interface IVeveProvider
    {
        IEnumerable<CustomerModel> GetCustomers();
    }
}
