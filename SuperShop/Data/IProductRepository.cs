using System.Linq;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllWithUsers();
    }
}