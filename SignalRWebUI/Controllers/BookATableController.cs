using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.BookingDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookATableController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5002/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            HttpClient client2 = new HttpClient();
            HttpResponseMessage response = await client2.GetAsync("https://localhost:5002/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;

            createBookingDto.Description = "b";

            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:5002/api/Booking", stringContent);



            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }


            //var client = _clientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createBookingDto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("https://localhost:5002/api/Booking", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
    }
}
