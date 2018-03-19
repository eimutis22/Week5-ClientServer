using ProductServer.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServer.DAL
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IList<Product>> SupplierProductsAsync();
    }
}
