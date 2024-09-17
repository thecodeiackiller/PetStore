using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Petstore.UILogic;
using PriceChanges.Extensions;

using Microsoft.Extensions.Hosting;

namespace Petstore
{
    public class Program
    {
        
        static IServiceProvider service = CreateServiceCollection();

        static void Main(string[] args)
        {

            var productlogic = service.GetService<IProductLogic>();
            // Resolving our service
            var userInput = service.GetService<IUILogic>();
            // Calling methods from UserInput class (i.e. using our service through DI)
            if (userInput != null)
            {
                userInput.ListUserInputOptions();
                userInput.GetUserInput();
                userInput.ExecuteUserInput();
            }
            return;
            

        }


        // DI is typically done through IServiceCollection
        // Different from IServiceProvider, IServiceCollection can't be passed into a class constructor
        static IServiceProvider CreateServiceCollection()
        {
            var newServiceCollection = new ServiceCollection();

            // Configuring Services here
            newServiceCollection.AddTransient<IProductLogic, ProductLogic>();
            newServiceCollection.AddTransient<IUILogic, UserInput>();


            return newServiceCollection.BuildServiceProvider();
        }
    }
}
