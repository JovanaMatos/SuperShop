using System.Linq;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IQueryable<Order> GetOrdersAsync(string userName);
    }
}
