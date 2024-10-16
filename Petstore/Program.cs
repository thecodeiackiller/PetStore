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
                userInput.ListUserInputOptions();
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

            newServiceCollection.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source=products.db"));
            return newServiceCollection.BuildServiceProvider();
        }
    }
}
