using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Petstore.UILogic;
using PriceChanges.Extensions;
using PetStore.Data;

using Microsoft.Extensions.Hosting;

namespace Petstore
{
    public class Program
    {
        
        static IServiceProvider service = CreateServiceCollection();

        static void Main(string[] args)
        {

            
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
        static IServiceProvider CreateServiceCollection() // This is where our dependency injection starts. This is setup through the Microsoft.Extensions.DependencyInjection namespace
        {
            // The entirety of dependency injection is done through services. We create a service first, then we use that service. There are different classes for each.
            var newServiceCollection = new ServiceCollection();

            // Configuring Services here
            newServiceCollection.AddTransient<IProductLogic, ProductLogic>(); // AddTransient is used here to say a new instance of the service is created everytime its requested
            newServiceCollection.AddTransient<IUILogic, UserInput>(); // There are other method such as AddSingleton that ultimately define the state of the service when called
            newServiceCollection.AddTransient<IProductRepository,ProductRepository>(); //We added a Singleton so the Service would be available for the entire lifetime of the application. 


            return newServiceCollection.BuildServiceProvider();
        }
    }
}
