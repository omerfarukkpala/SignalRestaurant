using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Product/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            //Ürün listesi gelirken kategori adları
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> category = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
                ViewBag.Category = category;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5002/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5002/api/Product?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            //Ürün listesi gelirken kategori adlarını çekiyorum
            var client2 = _clientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:5002/api/Category");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
                List<SelectListItem> category = (from x in values2
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
                ViewBag.Category = category;
            }


            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Product/GetProduct?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5002/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}
