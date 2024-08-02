using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Petstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and Initializing product class
            
            ProductLogic productLogic = new ProductLogic();

            string userInput = string.Empty;
            Console.WriteLine("Press 1 to add product");
            Console.WriteLine("Press 2 to search for product by name");
            Console.WriteLine("Type 'exit' to exit the program");
            

            while (userInput.ToLower() != "exit")
            {
                try
                {
                    userInput = Console.ReadLine();
                    // Let's implement some expection handling in this application
                    // If user input is different from what we would expect, lets use try catch for practice

                    // Need to add functionality to ask for how many products you want to enter, then create a for loop from that point on.
                    if(userInput != "1" && userInput.ToLower() != "exit" && userInput != "2")
                    {
                        throw new Exception("Enter 1 to add a new product or enter 'exit' to end the program.");
                    }

                    if (userInput == "1")
                    {
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
                        productLogic.AddProduct(product);
                        Console.WriteLine($"Successfully Inserted:\nProduct Name: {name} \nProduct Description: {description} \nProduct Material: {material}");
                        Console.WriteLine();
                        Console.WriteLine("All Products:");
                        productLogic.GetAllProducts();

                        Console.WriteLine();
                        Console.WriteLine("Press 1 to add product");
                        Console.WriteLine("Press 2 to search for product by name");
                        Console.WriteLine("Type 'exit' to exit the program");

                    }
                    else if(userInput == "2")
                    {
                        Console.WriteLine("Enter the name of the dog leash:");

                        Console.WriteLine();
                        DogLeash dogLeash = productLogic.GetDogLeashByName(Console.ReadLine());
                        Console.WriteLine($"Name: {dogLeash.Name}\nMaterial: {dogLeash.Material}");

                        Console.WriteLine();
                        Console.WriteLine("Press 1 to add product");
                        Console.WriteLine("Press 2 to search for product by name");
                        Console.WriteLine("Type 'exit' to exit the program");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                
            } 
        }
    }
}
