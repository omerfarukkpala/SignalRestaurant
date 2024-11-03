using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MessageDtos;
using System.Text;


namespace SignalRWebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminMessageController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Message");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Message?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminMessage");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Message/GetMessage?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMessageDto>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> ChangeMessageStatusTrue(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Message/ChangeMessageStatusTrue?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminMessage");
            }
            return View();
        }

        public async Task<IActionResult> ChangeMessageStatusFalse(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Message/ChangeMessageStatusFalse?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminMessage");
            }
            return View();
        }

    }
}
