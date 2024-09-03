using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Petstore.UILogic;
using PriceChanges.Extensions;

namespace Petstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductLogic productLogic = new ProductLogic();
            IUILogic userDoingStuff = new UserInput();

            userDoingStuff.ListUserOptions();
            userDoingStuff.GetUserInput();
            userDoingStuff.ExecuteUserInput();
            
        
        }
    }
}
