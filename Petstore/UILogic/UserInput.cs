using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Petstore.Data.Repositories;
using Petstore.DogLeashValidator;
using Petstore.Models;
using Petstore.Services;
using PriceChanges.Extensions;

namespace Petstore.UILogic
{
    public class UserInput : IUILogic
    {
        private readonly IProductService productService;
        private readonly IOrderRepository orderRepository;
        private readonly IUserInputRepository userInputRepository;
        
        public UserInput(IProductService productService, IOrderRepository orderRepository, IUserInputRepository userInputRepository)
        {
            this.productService = productService;
            this.orderRepository = orderRepository;
            this.userInputRepository = userInputRepository; 
        }

        public void ListUserInputOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 to add product to the database (and potentially to in memory data structure");
            Console.WriteLine("Press 2 to search for product details by Id");
            Console.WriteLine("Press 3 to add product and orders with json");
            Console.WriteLine("Type 'exit' to exit the program");
        }


        public static string userinput {  get; set; }
        public void GetUserInput()
        {

            userinput = userInputRepository.GetInput();
        }
        public void ExecuteUserInput() 
        {
                switch (userinput)
                {
                    case "1":
                        AddProduct();
                        break;
                    
                    case "2":
                        SearchProductById();
                        break;

                    case "3":
                    var jsonOrder = JsonSerializer.Deserialize<Order>(Console.ReadLine());
                    orderRepository.AddOrder(jsonOrder);
                    break;

                    case "exit":
                        return;

                    default:
                    Console.WriteLine("Please enter 1,2,3, or exit.");
                        break;
                }
            
            ListUserInputOptions();
            GetUserInput();
            ExecuteUserInput();
        }    
        
        public void AddProduct()
        {
            Console.WriteLine("Lets add a product to the db.");

            Product prod = new Product()
            {
                Name = userInputRepository.GetInput(),
                Quantity = int.Parse(userInputRepository.GetInput()),
                Description = userInputRepository.GetInput(),
                OrderId = 1
            };

            productService.AddProduct(prod);
        }

        public void SearchProductById()
        {
            Console.WriteLine("Please enter Id of product");
            int productId = int.Parse(userInputRepository.GetInput());
            var product = productService.GetProductById(productId);

            try
            {
                if (product != null)
                {
                    // We also might want to consider printing out the properties of the dogleash whos name we provided.
                    Console.WriteLine($"Name: {product.Name}\n Price: {product.Price}\n Quantity: {product.Quantity}");
                    Console.WriteLine($"Description: {product.Description}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Product doesn't exist in our db. Select 2 again to try to insert a different name or view all products by pressing 8");
                    userinput = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
