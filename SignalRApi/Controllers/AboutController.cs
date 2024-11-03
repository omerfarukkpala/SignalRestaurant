using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }

        //    public AboutController(IAboutService aboutService)
        //    {
        //        _aboutService = aboutService;
        //    }

        //    [HttpGet]
        //    public IActionResult AboutList()
        //    {
        //        var values = _aboutService.TGetListAll();
        //        return Ok(values);
        //    }

        //    [HttpPost]
        //    public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        //    {
        //        About about = new About()
        //        {
        //            Title = createAboutDto.Title,
        //            Description = createAboutDto.Description,
        //            ImageUrl = createAboutDto.ImageUrl
        //        };

        //        _aboutService.TAdd(about);
        //        return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        //    }
        //    [HttpDelete]
        //    public IActionResult DeleteAbout(int id)
        //    {
        //        var value = _aboutService.TGetByID(id);
        //        _aboutService.TDelete(value);
        //        return Ok("Hakkımda kısmı başarılı bir şekilde silindi");
        //    }

        //    [HttpPut]
        //    public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        //    {
        //        About about = new About()
        //        {
        //            AboutID = updateAboutDto.AboutID,
        //            Title = updateAboutDto.Title,
        //            Description = updateAboutDto.Description,
        //            ImageUrl = updateAboutDto.ImageUrl
        //        };
        //        _aboutService.TUpdate(about);
        //        return Ok("Hakkımda kısmı başarılı bir şekilde güncellendi");
        //    }

        //    [HttpGet("GetAbout")]
        //    public IActionResult GetAbout(int id)
        //    {
        //        var value = _aboutService.TGetByID(id);
        //        return Ok(value);
        //    }
        //}
    }
}