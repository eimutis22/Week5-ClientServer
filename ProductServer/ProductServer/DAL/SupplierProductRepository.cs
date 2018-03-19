using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProductServer.Models.Products;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
            var found = ctx.Products.Find(productID);
            if (found != null)
            {
                if (found.Quantity - quantityPurchased < 0) return false;
                else return true;
            }
            return false;
        }

        public async Task<Product> deleteAsync(int id)
        {
            Product product = await ctx.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return product; ;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task<IList<Product>> getEntitiesAsync()
        {
            return await ctx.Products.ToListAsync();
        }

        public async Task<Product> GetEntityAsync(int id)
        {
            Product product = await ctx.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<IList<Product>> GetReorderListAsync()
        {
            return await ctx.Products.Where(p => p.Quantity <= p.ReOrderLevel).ToListAsync();
        }

        public float GetStockCost(int ProductID)
        {
            Product p = ctx.Products.Find(ProductID);
            if (p != null)
            {
                return (p.Price * p.Quantity);
            }
            return -999f;
        }

        public async Task<Product> OrderItemAsync(Product p, int Quantity)
        {
            if (p.Quantity - Quantity > 0)
            {
                p.Quantity -= Quantity;
                ctx.Entry(p).State = EntityState.Modified;
                try
                {
                    await ctx.SaveChangesAsync();
                    return p; // Return changed product accepted
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(p.ProductID))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return p; // return unchanged product
        }

        public async Task<Product> PostEntityAsync(Product Entity)
        {
            ctx.Products.Add(Entity);
            await ctx.SaveChangesAsync();
            return Entity;
        }

        public async Task<Supplier> PostEntityAsync(Supplier Entity)
        {
            ctx.Suppliers.Add(Entity);
            await ctx.SaveChangesAsync();
            return Entity;
        }

        public async Task<Product> PutEntityAsync(Product Entity)
        {
            ctx.Entry(Entity).State = EntityState.Modified;

            try
            {
                await ctx.SaveChangesAsync();
                return Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Entity.ProductID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool SupplierExists(int id)
        {
            return ctx.Suppliers.Count(e => e.SupplierID == id) > 0;
        }
        private bool ProductExists(int id)
        {
            return ctx.Products.Count(e => e.ProductID == id) > 0;
        }

        public async Task<Supplier> PutEntityAsync(Supplier Entity)
        {
            ctx.Entry(Entity).State = EntityState.Modified;

            try
            {
                await ctx.SaveChangesAsync();
                return Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(Entity.SupplierID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IList<Product>> SupplierProductsAsync()
        {
            return await ctx.Products.Include("associatedSupplier").ToListAsync();
        }

        async Task<Supplier> IRepository<Supplier>.deleteAsync(int id)
        {
            Supplier supplier = await ctx.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }
            ctx.Suppliers.Remove(supplier);
            await ctx.SaveChangesAsync();

            return supplier;
        }

        async Task<IList<Supplier>> IRepository<Supplier>.getEntitiesAsync()
        {   
            return await ctx.Suppliers.ToListAsync();
        }

        async Task<Supplier> IRepository<Supplier>.GetEntityAsync(int id)
        {
            Supplier supplier = await ctx.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }

            return supplier;
        }
    }
}