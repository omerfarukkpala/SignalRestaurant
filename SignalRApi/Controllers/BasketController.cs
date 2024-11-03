using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByTableDetailID(int id)
        {
            var values = _basketService.TGetBasketByTableDetailID(id);
            return Ok(values);
        }

        [HttpGet("GetBasketListByTableDetailWithProductName")]
        public IActionResult GetBasketListByTableDetailWithProductName(int id)
        {
            var values = _basketService.TGetBasketListByTableDetailWithProductName(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                TableDetailID = 4,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            var basket = _basketService.TGetByID(id);
            _basketService.TDelete(basket);
            return Ok();
        }
    }
}
