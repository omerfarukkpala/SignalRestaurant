using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public DiscountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Discount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Discount", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Discount");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Discount?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Discount");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Discount/GetDiscount?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/Discount", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Discount");
            }
            return View();
        }

        public async Task<IActionResult> DiscountStatusChangeTrue(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Discount/DiscountStatusChangeTrue?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Discount");
            }
            return View();
        }

        public async Task<IActionResult> DiscountStatusChangeFalse(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Discount/DiscountStatusChangeFalse?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Discount");
            }
            return View();
        }
    }
}
