using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCOunt")]
        public IActionResult TotalOrderCOunt()
        {
            var values = _orderService.TTotalOrderCount();
            return Ok(values);
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var values = _orderService.TActiveOrderCount();
            return Ok(values);
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var values = _orderService.TLastOrderPrice();
            return Ok(values);
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var values = _orderService.TTodayTotalPrice();
            return Ok(values);
        }
    }
}
