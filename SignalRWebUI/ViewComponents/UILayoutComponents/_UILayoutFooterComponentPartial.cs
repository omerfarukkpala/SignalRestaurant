using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Contact");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);

        }
    }
}
