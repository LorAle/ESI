using ESI_Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI_Context
{
    public interface IProductProvider
    {
        IEnumerable<ProductModel> GetProducts();
    }
}
