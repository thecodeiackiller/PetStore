using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petstore.Models;
using Petstore.Services;
using Petstore.Data.Repositories;
using System.Security.Cryptography.X509Certificates;
using Petstore.Data;
using Petstore.UILogic;


namespace PetStore.Test
{
    [TestClass]
    public class ProductLogicTest
    {
        private Mock<IProductRepository> _productRepository;
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IUserInputRepository> _userInputRepository;
        private UserInput _userInput;
        
        
        [TestInitialize]
        public void Setup() 
        {
            _productRepository = new Mock<IProductRepository>();
            _orderRepository = new Mock<IOrderRepository>();
            _userInputRepository = new Mock<IUserInputRepository>();
            _userInput = new UserInput(new ProductService(_productRepository.Object), _orderRepository.Object,_userInputRepository.Object);
        }


        [TestMethod]
        public void TestMethod1()
        {
            // Arrange: 
            _userInputRepository.Setup(x => x.GetInput()).Returns("10");

            _productRepository.Setup(x => x.getProductById(10))
                .Returns(new Product { Id = 10, Name = "Test Product" });

            // Act
            _userInput.SearchProductById();

            // Assert
            _productRepository.Verify(x => x.getProductById(10), Times.Once);

            
        }
    }
}