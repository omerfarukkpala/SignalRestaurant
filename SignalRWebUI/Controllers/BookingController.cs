using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Booking");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Booking", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Booking?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Booking/GetBooking?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/Booking", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Booking/BookingStatusApproved?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Booking/BookingStatusCancelled?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }
    }
}
