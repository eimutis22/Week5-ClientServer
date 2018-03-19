using ProductServer.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServer.DAL
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IList<Product>> GetReorderListAsync();
        Task<Product> OrderItemAsync(Product p, int Quantity);

        float GetStockCost(int ProductID);
        bool CheckStock(int productID, int quantityPurchased);
    }
}
