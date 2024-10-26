using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petstore.Data.Repositories;

namespace petstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository) 
        {
            this._orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var result = await _orderRepository.GetAllOrders();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
