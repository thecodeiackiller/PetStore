using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PriceChanges.Extensions;
namespace Petstore.UILogic
{
    public class UserInput : IUILogic
    {
        public static string userInput { get; set; }
        List<string> validUserInputs = new List<string> { "1", "2", "8", "9", "10", "exit"};
        Product product = new Product();
        ProductLogic productLogic = new ProductLogic();

        public void ListUserInputOptions()
        {
            Console.WriteLine("Press 1 to add product");
            Console.WriteLine("Press 2 to search for product details by name");
            Console.WriteLine("Press 8 to view all products");
            Console.WriteLine("Press 9 to view only in stock items");
            Console.WriteLine("Press 10 to view OUT OF stock items");
            Console.WriteLine("Type 'exit' to exit the program");
        }

        public void GetUserInput()
        {
            
            string input = Console.ReadLine();

            if (validUserInputs.Contains(input.ToLower()))
            {
                
                userInput = input;
            }
            else
            {
                throw new Exception("Enter 1,2,8,9,10 or type 'exit' to end the program.");
            }
        }

        public void ExecuteUserInput() 
        {
            
            
                switch (userInput)
                {
                    case "1":

                        var product = new DogLeash();
                        Console.WriteLine("Enter name of product:");
                        product.Name = Console.ReadLine();
                        string name = product.Name;
                        Console.WriteLine("Enter description of product:");
                        product.Description = Console.ReadLine();
                        string description = product.Description;
                        Console.WriteLine("Enter material of product:");
                        product.Material = Console.ReadLine();
                        string material = product.Material;
                        Console.WriteLine();
                        productLogic.AddProduct(product as DogLeash);
                        Console.WriteLine($"Successfully Inserted:\nProduct Name: {name} \nProduct Description: {description} \nProduct Material: {material}");
                        Console.WriteLine();
                        Console.WriteLine("All Products:");
                        productLogic.GetAllProducts();
                        
                        break;
                    case "2":

                        Console.WriteLine("Enter the name of the dog leash:");
                        Console.WriteLine();
                        DogLeash dogLeash = productLogic.GetDogLeashByName(Console.ReadLine());
                        Console.WriteLine($"Name: {dogLeash.Name}\nMaterial: {dogLeash.Material}\nPrice: {dogLeash.Price}");
                        Console.WriteLine($"Discounted Price for {dogLeash.Name} : ${dogLeash.Price.DiscountThisPrice()}");
                        
                        break;

                    case "8":
                        productLogic.GetAllProducts();
                        
                        break;
                    case "9":
                        productLogic.GetInStockItems();
                        
                        break;
                    case "10":
                        productLogic.GetOutOfStockItems();
                        
                        break;

                    case "exit":
                    return;

                    default:
                        Console.WriteLine("Boy, you done EFFED up!");
                        break;
                }
            
            ListUserInputOptions();
            GetUserInput();
            ExecuteUserInput();
        }        
    }
}
