using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMService.Models;

namespace OrderMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> Orders = new();

        [HttpGet]
        public IEnumerable<Order> GetAll() => Orders;

        [HttpPost]
        public ActionResult PlaceOrder(Order order)
        {
            order.OrderId = Orders.Count + 1;
            Orders.Add(order);
            return CreatedAtAction(nameof(GetAll), new { id = order.OrderId }, order);
        }
    }
}
