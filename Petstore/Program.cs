using System.Runtime.CompilerServices;
using System.Xml.Linq;
using PriceChanges.Extensions;

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
            Console.WriteLine("Press 2 to search for product details by name");
            Console.WriteLine("Press 8 to view all products");
            Console.WriteLine("Press 9 to view only in stock items");
            Console.WriteLine("Press 10 to view OUT OF stock items");
            Console.WriteLine("Type 'exit' to exit the program");
            

            while (userInput.ToLower() != "exit")
            {
                try
                {
                    userInput = Console.ReadLine();
                    // Let's implement some expection handling in this application
                    // If user input is different from what we would expect, lets use try catch for practice

                    // Need to add functionality to ask for how many products you want to enter, then create a for loop from that point on.
                    if(userInput != "1" && 
                        userInput.ToLower() != "exit" && 
                        userInput != "2" && 
                        userInput != "8" && 
                        userInput != "9" &&
                        userInput != "10")
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
                        Console.WriteLine($"Name: {dogLeash.Name}\nMaterial: {dogLeash.Material}\nPrice: {dogLeash.Price}");
                        // Need to also print the price of the product per the extension method instructions
                        //Console.WriteLine($"Discounted Price for {dogLeash.Name} : ${DecimalExtensions.ToDecimal(dogLeash.Price)}"); Commenting this out but leaving for comparability with the Extension Mehtod
                        Console.WriteLine($"Discounted Price for {dogLeash.Name} : ${dogLeash.Price.DiscountThisPrice()}"); // And we can do this because we have extended the decimal type which is a primitive type 

                        Console.WriteLine("Press 1 to add product");
                        Console.WriteLine("Press 2 to search for product by name");
                        Console.WriteLine("Type 'exit' to exit the program");

                        
                    }
                    else if(userInput == "8")
                    {
                        productLogic.GetAllProducts();
                    }
                    else if (userInput == "9")
                    {
                        productLogic.GetInStockItems();
                    }
                    else if( userInput == "10")
                    {
                        productLogic.GetOutOfStockItems();
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
