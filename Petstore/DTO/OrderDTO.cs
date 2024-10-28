using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.DTO
{
    public class OrderDTO
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
