using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5002/api/Product/GetTake6ProductList");

            //var responseMessage = await client.GetAsync("https://localhost:5002/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);

        }
    }
}
