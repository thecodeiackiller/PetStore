using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petstore.Data.Repositories;
using Petstore.DTO;

namespace petstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var results = await _productRepository.GetAllProducts();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productNumber:int}")]
        public async Task<IActionResult> GetProductsByProductNumber(int productNumer)
        {
            try
            {
                var products = _productRepository.GetProductsByProductNumber(productNumer);
                List<ProductDTO> results = _mapper.Map<List<ProductDTO>>(products);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
