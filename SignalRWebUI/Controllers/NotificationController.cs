using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public NotificationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Notification");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Notification", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Notification");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Notification?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Notification");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Notification/GetNotification?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/Notification", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Notification");
            }
            return View();
        }

        public async Task<IActionResult> UpdateNotificationStatusTrue(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.GetAsync($"https://localhost:5002/api/Notification/UpdateNotificationStatusTrue?id={id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateNotificationStatusFalse(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.GetAsync($"https://localhost:5002/api/Notification/UpdateNotificationStatusFalse?id={id}");
            return RedirectToAction("Index");
        }
    }
}
