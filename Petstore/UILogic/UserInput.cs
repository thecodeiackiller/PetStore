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
using Petstore.Models;
using PetStore.Data;
using PriceChanges.Extensions;

namespace Petstore.UILogic
{
    public class UserInput : IUILogic
    {
        private readonly IProductRepository? productRepository;
        public static string userInput { get; set; }
        List<string> validUserInputs = new List<string> { "1", "2", "8", "9", "10", "exit"};
        Product product = new Product();


        ProductLogic productLogic;

        public UserInput(IProductRepository? productRepository)
        {
            this.productRepository = productRepository;
        }

        public void ListUserInputOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 to add product through JSON payload");
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
                userInput = null;
                Console.WriteLine("Enter 1,2,8,9,10 or type 'exit' to end the program.");
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

                    if (result.IsValid)
                    {
                        productLogic.AddProduct(dogleashObject);
                        Console.WriteLine($"Products Entered:\n Name: {dogleashObject.Name}\n Price: {dogleashObject.Price}\n" +
                            $"Quantity: {dogleashObject.Quantity}\n Description: {dogleashObject.Description}");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error: {error}");
                        }
                        // Per instructions, throw a ValidationException here
                    }




                    // Whatever we put in the Console.Readline will be in the form of JSON
                    // We have to match, or serialize that JSON in the form of the properties within our DogLeash class and from the Product class it inherits from



                    productLogic.GetAllProducts();
                        // TODO: Need to Use the validator in the add method in ProductLogic. Throw a ValidationException if the DogLeash isn't valid.
                        break;
                    case "2":
                        Console.WriteLine("Please enter name of product");

                    var product = productLogic.GetProductByNameGenericMethod<DogLeash>(Console.ReadLine());
                    

                    try
                    {
                        if(product != null)
                        {
                            // We also might want to consider printing out the properties of the dogleash whos name we provided.
                            Console.WriteLine($"Name: {product.Name}\n Material: {product.Material}\n Price: {product.Price}\n Quantity: {product.Quantity}");
                            Console.WriteLine($"Description: {product.Description}");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Product doesn't exist in our db. Select 2 again to try to insert a different name or view all products by pressing 8");
                            userInput = null;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                       
                        break;

                    case "8":
                    Console.WriteLine();
                    Console.WriteLine("All Products:");
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
                        break;
                }
            
            ListUserInputOptions();
            GetUserInput();
            ExecuteUserInput();
        }        
    }
}
