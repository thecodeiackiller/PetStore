using System.Xml.Linq;

namespace Petstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            Console.WriteLine("Press 1 to add product");
            Console.WriteLine("Type 'exit' to exit the program after the completion of inserting a new product");

            while (userInput.ToLower() != "exit")
            {
                try
                {
                    userInput = Console.ReadLine();
                    // Let's implement some expection handling in this application
                    // If user input is different from what we would expect, lets use try catch for practice

                    // Need to add functionality to ask for how many products you want to enter, then create a for loop from that point on.
                    if(userInput != "1" && userInput.ToLower() != "exit")
                    {
                        throw new Exception("Follow directions shithead. Enter 1 to add a product or enter 'exit' to end the program.");
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
                        Console.WriteLine($"Successfully Inserted:\nProduct Name: {name} \nProduct Description: {description} \nProduct Material: {material}");
                        Console.WriteLine();
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
