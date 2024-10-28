using Microsoft.EntityFrameworkCore;
using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _db;

        public OrderRepository(ProductContext db)
        {
            _db = db;
        }
        public void AddOrder(Order order)
        {
            _db.Add(order);
            _db.SaveChanges();
        }

        public async Task<Order> RetriveOrderByOrderNum(int orderNum)
        {
            return await _db.Orders.Include(e => e.Products).Where(e => e.OrderNumber == orderNum).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _db.Orders.ToListAsync();
        }


    }
}
