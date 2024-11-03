using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _UILayoutSocialMediaComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/SocialMedia");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
