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
        public void addOrder(Order order)
        {
            _db.Add(order);
            _db.SaveChanges();
        }

        public async Task<Order> retriveOrderById(int id)
        {
            return await _db.Orders.Include(e => e.Products).Where(e => e.OrderId == id).FirstOrDefaultAsync();
        }


    }
}
