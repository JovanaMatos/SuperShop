using System.Collections.Generic;
using System.Threading.Tasks;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        void UpdateAsync(T entity);

        void DeleteAsync(T entity);

        bool ExistAsync(int id);
    }
}