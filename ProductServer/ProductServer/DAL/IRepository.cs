using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServer.DAL
{
    public interface IRepository<T>
    {
        Task<IList<T>> getEntitiesAsync();
        Task<T> GetEntityAsync(int id);
        Task<T> PutEntityAsync(T Entity);
        Task<T> PostEntityAsync(T Entity);
        Task<T> deleteAsync(int id);
    }
}
