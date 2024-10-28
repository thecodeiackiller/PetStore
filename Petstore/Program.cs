using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Petstore.UILogic;
using PriceChanges.Extensions;

using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Petstore.Data.Repositories;
using Petstore.Services;
using Petstore.Data;
using System.Reflection;
using System.Diagnostics;
using Petstore.DTO;
using Petstore.Models;

namespace Petstore
{
    public class Program
    {
        static IServiceProvider service = CreateServiceCollection();
        static void Main(string[] args)
        {
            var userInput = service.GetService<IUILogic>();
            if (userInput != null)
            {
                Console.WriteLine("Taking a look at metadata and reflection");

                Type orderDTOType = typeof(OrderDTO);

                Console.WriteLine($"OrderDTO Name: {orderDTOType.Name}");
                Console.WriteLine($"OrderDTO Namespace: {orderDTOType.Namespace}");

                Console.WriteLine("All of the properties in the Type for OrderDTO:");

                foreach(var property in orderDTOType.GetProperties())
                {
                    Console.WriteLine($"Property Name: {property.Name}\n Property Type: {property.PropertyType}");
                }

                Console.WriteLine("Showcasing runtime values:");

                OrderDTO orderDto = new OrderDTO
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = 123
                };
                Console.WriteLine("\n** Runtime Instance Values **");
                Console.WriteLine($"Order Number: {orderDto.OrderNumber}");
                Console.WriteLine($"Order Date: {orderDto.OrderDate}");

                userInput.ListUserInputOptions();
                userInput.GetUserInput();
                userInput.ExecuteUserInput();
            }
        }
        static IServiceProvider CreateServiceCollection() 
        {
            var newServiceCollection = new ServiceCollection();
            newServiceCollection.AddTransient<IUILogic, UserInput>(); 
            newServiceCollection.AddTransient<IProductRepository,ProductRepository>(); 
            newServiceCollection.AddTransient<IOrderRepository, OrderRepository>();
            newServiceCollection.AddTransient<IProductService, ProductService>();
            newServiceCollection.AddTransient<IUserInputRepository, UserInputRepository>();

            newServiceCollection.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source=products.db"));
            newServiceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            return newServiceCollection.BuildServiceProvider();
        }
    }
}
