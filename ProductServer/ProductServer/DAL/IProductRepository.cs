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
        float GetStockCost(int ProductID);
        bool CheckStock(int productID, int quantityPurchased);
        Task<Product> OrderItemAsync(Product p, int Quantity);
    }
}
