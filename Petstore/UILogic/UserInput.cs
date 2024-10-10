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
            Console.WriteLine("Press 1 to add product to the database (and potentially to in memory data structure");
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
                    // Not going to worry about validation here for now
                    // We need to store input (Name, Quantity, Description, etc) into the actual Product fields to ultimately a
                    Console.WriteLine("Lets add a product to the db.");
                    Product prod = new Product();

                    Console.WriteLine("Insert product name:");
                    prod.Name =  Console.ReadLine();

                    //Console.WriteLine("Insert price");
                    //prod.Price = decimal.Parse(Console.ReadLine()); 

                    Console.WriteLine("Insert product quantity:");
                    prod.Quantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insert product description:");
                    prod.Description = Console.ReadLine();

                    // productLogic.AddProduct(prod);
                    productRepository.addProduct(prod);
                    
                    // productLogic.GetAllProducts();
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
