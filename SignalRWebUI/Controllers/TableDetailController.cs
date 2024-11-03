using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TableDetailDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class TableDetailController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public TableDetailController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/TableDetails");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTableDetailDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTableDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTableDetail(CreateTableDetailDto createTableDetailDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTableDetailDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/TableDetails", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TableDetail");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTableDetail(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/TableDetails?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TableDetail");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTableDetail(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/TableDetails/GetTableDetail?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTableDetailDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTableDetail(UpdateTableDetailDto updateTableDetailDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTableDetailDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/TableDetails", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TableDetail");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/TableDetails");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTableDetailDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
