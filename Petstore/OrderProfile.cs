using AutoMapper;
using Petstore.DTO;
using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            this.CreateMap<Order,OrderDTO>();
        }

    }
}
