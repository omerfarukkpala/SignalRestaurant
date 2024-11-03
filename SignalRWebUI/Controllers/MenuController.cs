using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;

using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public MenuController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5002/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto()
            {
                ProductID = id
            };
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Basket", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
