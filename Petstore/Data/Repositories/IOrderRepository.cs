using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data.Repositories
{
    public interface IOrderRepository
    {

        public void AddOrder(Order order);
        public Task<Order> RetriveOrderById(int id);

        public Task<List<Order>> GetAllOrders();
    }
}
