using Microsoft.AspNetCore.Mvc;
using OrderAPI.Order_Service;
using Shared;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("start-consuming-service")]
        public async Task<IActionResult> StartService()
        {
            await orderService.StartConsumingService();
            return NoContent();
        }

        [HttpGet("get-product")]
        public IActionResult GetOrder()
        {
            var prodcuts = orderService.GetProducts();
            return Ok(prodcuts);
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder(Order order)
        {
            orderService.AddOrder(order);
            return Ok("Order placed.");
        }

        [HttpGet("order-summary")]
        public IActionResult GetOrderSummary() => Ok(orderService.GetOrdersSummary());
    }
}
