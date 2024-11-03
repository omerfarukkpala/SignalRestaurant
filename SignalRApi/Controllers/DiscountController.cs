using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("İndirim Bilgisi Eklendi");


            //_discountService.TAdd(new Discount()
            //{
            //    Title = createDiscountDto.Title,
            //    Amount = createDiscountDto.Amount,
            //    Description = createDiscountDto.Description,
            //    ImageUrl = createDiscountDto.ImageUrl,
            //    Status = false
            //});
            //return Ok("İndirim bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi silindi");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));

            //var value = _discountService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {

            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("İndirim Bilgisi Güncellendi");

            //_discountService.TUpdate(new Discount()
            //{
            //    DiscountID = updateDiscountDto.DiscountID,
            //    Title = updateDiscountDto.Title,
            //    Amount = updateDiscountDto.Amount,
            //    Description = updateDiscountDto.Description,
            //    ImageUrl = updateDiscountDto.ImageUrl,
            //    Status = false
            //});
            //return Ok("İndirim bilgisi güncellendi");
        }

        [HttpGet("DiscountStatusChangeTrue")]
        public IActionResult DiscountStatusChangeTrue(int id)
        {
            var value = _discountService.TGetByID(id);
            value.Status = true;
            _discountService.TUpdate(value);
            return Ok("İndirim aktif edildi");
        }

        [HttpGet("DiscountStatusChangeFalse")]
        public IActionResult DiscountStatusChangeFalse(int id)
        {


            var value = _discountService.TGetByID(id);
            value.Status = false;
            _discountService.TUpdate(value);
            return Ok("İndirim pasif edildi");
        }

        [HttpGet("GetDiscountListByStatusTrue")]
        public IActionResult GetDiscountListByStatusTrue()
        {
            var values = _discountService.TGetDiscountListByStatusTrue();
            return Ok(values);
        }

    }
}
