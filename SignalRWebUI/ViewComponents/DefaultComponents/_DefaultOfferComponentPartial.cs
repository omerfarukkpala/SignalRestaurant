using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5002/api/Discount/GetDiscountListByStatusTrue");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
            return View(values);

        }
    }
}
