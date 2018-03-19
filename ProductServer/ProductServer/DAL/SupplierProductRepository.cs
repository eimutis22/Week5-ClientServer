using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProductServer.Models.Products;

namespace ProductServer.DAL
{
    public class SupplierProductRepository : IProductRepository, ISupplierRepository, IDisposable
    {
        private ProductDbContext ctx;

        public SupplierProductRepository(ProductDbContext ctx)
        {
            this.ctx = ctx;
        }


        public bool CheckStock(int productID, int quantityPurchased)
        {
            throw new NotImplementedException();
        }

        public Task<Product> delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> getEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetReorderList()
        {
            throw new NotImplementedException();
        }

        public float GetStockCost(int ProductID)
        {
            throw new NotImplementedException();
        }

        public Task<Product> OrderItem(Product p, int Quantity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> PostEntity(Product Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> PostEntity(Supplier Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> PutEntity(Product Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> PutEntity(Supplier Entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> SupplierProducts()
        {
            throw new NotImplementedException();
        }

        Task<Supplier> IRepository<Supplier>.delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<IList<Supplier>> IRepository<Supplier>.getEntities()
        {
            throw new NotImplementedException();
        }

        Task<Supplier> IRepository<Supplier>.GetEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}