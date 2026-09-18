using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using SuperShop.Helpers;

namespace SuperShop.Data
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public OrderRepository(
            DataContext context,
            IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public IQueryable<Order> GetOrdersAsync(string userName)
        {
            var user = _userHelper.GetUserByEmailAsync(userName).Result;

            if (user == null)
            {
                return null;
            }

            if (_userHelper.IsUserInRoleAsync(user, "Admin").Result)
            {
                return _context.Orders
                    .Include(o => o.User)
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }
    }
}
