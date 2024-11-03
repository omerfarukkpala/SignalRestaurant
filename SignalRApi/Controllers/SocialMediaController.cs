using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Sosyal Medya Bilgisi Eklendi");
            //_socialMediaService.TAdd(new SocialMedia()
            //{
            //    Icon = createSocialMediaDto.Icon,
            //    Title = createSocialMediaDto.Title,
            //    Url = createSocialMediaDto.Url,
            //});
            //return Ok("Sosyal medya bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal medya bilgisi silindi");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));

            //var value = _socialMediaService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
            //_socialMediaService.TUpdate(new SocialMedia()
            //{
            //    SocialMediaID = updateSocialMediaDto.SocialMediaID,
            //    Icon = updateSocialMediaDto.Icon,
            //    Title = updateSocialMediaDto.Title,
            //    Url = updateSocialMediaDto.Url,
            //});
            //return Ok("Sosyal medya bilgisi güncellendi");
        }
    }
}
