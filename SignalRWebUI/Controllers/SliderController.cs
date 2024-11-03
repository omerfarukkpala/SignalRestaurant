using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SliderController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Slider");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Slider", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Slider");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Slider?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Slider");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Slider/GetSlider?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/Slider", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Slider");
            }
            return View();
        }
    }
}
