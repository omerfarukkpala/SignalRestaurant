using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BasketController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Basket/GetBasketListByTableDetailWithProductName?id=4");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Basket?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        //public async Task<IActionResult> AddBasket(int id)
        //{
        //    var client = _clientFactory.CreateClient();
        //    var response = await client.PostAsync($"https://localhost:5002/api/Basket?id={id}", new StringContent("", Encoding.UTF8, "application/json"));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return NoContent();
        //}

    }
}
