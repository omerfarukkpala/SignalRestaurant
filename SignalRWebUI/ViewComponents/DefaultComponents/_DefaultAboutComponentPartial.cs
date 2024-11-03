using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/About");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);

        }
    }
}
