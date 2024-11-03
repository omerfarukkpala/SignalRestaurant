using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _sliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Öne Çıkan Bilgisi Eklendi");
            //_sliderService.TAdd(new Slider()
            //{
            //    Description1 = createSliderDto.Description1,
            //    Description2 = createSliderDto.Description2,
            //    Description3 = createSliderDto.Description3,
            //    Title1 = createSliderDto.Title1,
            //    Title2 = createSliderDto.Title2,
            //    Title3 = createSliderDto.Title3,
            //});
            //return Ok("Öne Çıkan bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan bilgisi silindi");
        }

        [HttpGet("GetSlider")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(_mapper.Map<GetSliderDto>(value));
            //var value = _sliderService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {

            var value = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(value);
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
            //_sliderService.TUpdate(new Slider()
            //{
            //    SliderID = updateSliderDto.SliderID,
            //    Description1 = updateSliderDto.Description1,
            //    Description2 = updateSliderDto.Description2,
            //    Description3 = updateSliderDto.Description3,
            //    Title1 = updateSliderDto.Title1,
            //    Title2 = updateSliderDto.Title2,
            //    Title3 = updateSliderDto.Title3,
            //});
            //return Ok("Öne Çıkan bilgisi güncellendi");
        }
    }
}
