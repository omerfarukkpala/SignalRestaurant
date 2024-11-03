using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Müşteri Yorum Bilgisi Eklendi");
            //_testimonialService.TAdd(new Testimonial()
            //{
            //    Name = createTestimonialDto.Name,
            //    Comment = createTestimonialDto.Comment,
            //    ImageUrl = createTestimonialDto.ImageUrl,
            //    Title = createTestimonialDto.Title,
            //    Status = createTestimonialDto.Status
            //});
            //return Ok("Müşteri yorum bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri yorum bilgisi silindi");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
            //var value = _testimonialService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
            //_testimonialService.TUpdate(new Testimonial()
            //{
            //    TestimonialID = updateTestimonialDto.TestimonialID,
            //    Name = updateTestimonialDto.Name,
            //    Comment = updateTestimonialDto.Comment,
            //    ImageUrl = updateTestimonialDto.ImageUrl,
            //    Title = updateTestimonialDto.Title,
            //    Status = updateTestimonialDto.Status
            //});
            //return Ok("Müşteri yorum bilgisi güncellendi");
        }
    }
}
