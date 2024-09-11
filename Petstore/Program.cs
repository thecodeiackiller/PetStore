using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Petstore.UILogic;
using PriceChanges.Extensions;
using Microsoft.Extensions.DependencyInjection; // This is correct for AddTransient
using Microsoft.Extensions.Hosting;

namespace Petstore
{
    public class Program
    {
        // Assigning the result of CreateServiceCollection() to a variable
        //static IServiceProvider service = CreateServiceCollection();

        static void Main(string[] args)
        {
            
            //var productLogic = service.GetService<IProductLogic>();
            
            // To access the members of the UserInput class, instead of the following, we can use DI.

            UserInput userInput = new UserInput();
            userInput.ListUserInputOptions();
            userInput.GetUserInput();
            userInput.ExecuteUserInput();

            // Dependency Injection 
            // Create the service provider - this just allows us to handle our service resolutions
            var serviceProvider = CreateServiceCollection();
            // Resolving our service

            // Calling methods from UserInput class (i.e. using our service through DI)

        }

        
        // DI is typically done in the program.cs or startup.cs classes
        // DI is typically done through IServiceCollection
        // Different from IServiceProvider, IServiceCollection can't be passed into a class constructor
        //static IServiceProvider CreateServiceCollection()
        //{
        //    var newServiceCollection = new ServiceCollection();
            
        //    // Configuring Services here
        //    newServiceCollection.AddTransient<IProductLogic, ProductLogic>();
            

        //    return newServiceCollection.BuildServiceProvider();
        //}
    }
}
