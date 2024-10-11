using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IOrderRepository
    {

        public void addOrder(Order order);
        public Task<Order> retriveOrderById(int id);
    }
}
