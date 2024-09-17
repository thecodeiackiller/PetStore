using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Petstore.DogLeashValidator;
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
                        // Instead of taking in each property as input, each property value should be created from JSON
                        // We could take input in the form of JSON and Deserialize it
                        // We know there are HttpClient, HttpRequest, JsonNode, JsonDocument
                        // Ultimately need to figure out which class gives us the method to deserialize the JSON

                        // So let's use our validator. At this point in writing this, we haven't dealt with JSON
                        DogLeashValidator.DogLeashValidator validate = new DogLeashValidator.DogLeashValidator();

                        var jsonPayload = Console.ReadLine();
                        var dogleashObject = JsonSerializer.Deserialize<DogLeash>(jsonPayload);

                        FluentValidation.Results.ValidationResult result = validate.Validate(dogleashObject);

                        if(result.IsValid)
                        {
                        productLogic.AddProduct(dogleashObject);
                            Console.WriteLine($"Products Entered:\n Name: {dogleashObject.Name}\n Price: {dogleashObject.Price}\n" +
                                $"Quantity: {dogleashObject.Quantity}\n Description: {dogleashObject.Description}");
                        }
                        else
                        {
                            foreach(var error in  result.Errors)
                            {
                                Console.WriteLine($"Error: {error}");
                            }
                        }
                    
                   
                        

                        // Whatever we put in the Console.Readline will be in the form of JSON
                        // We have to match, or serialize that JSON in the form of the properties within our DogLeash class and from the Product class it inherits from
                        

                        
                        productLogic.GetAllProducts();
                        // TODO: Need to Use the validator in the add method in ProductLogic. Throw a ValidationException if the DogLeash isn't valid.
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
