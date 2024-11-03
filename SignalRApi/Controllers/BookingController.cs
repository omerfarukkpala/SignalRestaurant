using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;



        public BookingController(IBookingService bookingService, IMapper mapper , IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;

        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Yapıldı");
            //var value = _mapper.Map<Booking>(createBookingDto);
            //_bookingService.TAdd(value);
            //return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        //public BookingController(IBookingService bookingService)
        //{
        //    _bookingService = bookingService;
        //}

        //[HttpGet]
        //public IActionResult BookingList()
        //{
        //    var values = _bookingService.TGetListAll();
        //    return Ok(values);
        //}

        //[HttpPost]
        //public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        //{
        //    Booking booking = new Booking()
        //    {
        //        Name = createBookingDto.Name,
        //        Phone = createBookingDto.Phone,
        //        Mail = createBookingDto.Mail,
        //        PersonCount = createBookingDto.PersonCount,
        //        Date = createBookingDto.Date,
        //        Description = "Rezervasyon Alındı"
        //    };

        //    _bookingService.TAdd(booking);
        //    return Ok("Rezervasyon başarılı bir şekilde eklendi");
        //}

        //[HttpDelete]
        //public IActionResult DeleteBooking(int id)
        //{
        //    var value = _bookingService.TGetByID(id);
        //    _bookingService.TDelete(value);
        //    return Ok("Rezervasyon başarılı bir şekilde silindi");
        //}

        //[HttpPut]
        //public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        //{
        //    Booking booking = new Booking()
        //    {
        //        BookingID = updateBookingDto.BookingID,
        //        Name = updateBookingDto.Name,
        //        Phone = updateBookingDto.Phone,
        //        Mail = updateBookingDto.Mail,
        //        PersonCount = updateBookingDto.PersonCount,
        //        Date = updateBookingDto.Date,
        //    };
        //    _bookingService.TUpdate(booking);
        //    return Ok("Rezervasyon başarılı bir şekilde güncellendi");
        //}

        //[HttpGet("GetBooking")]
        //public IActionResult GetBooking(int id)
        //{
        //    var value = _bookingService.TGetByID(id);
        //    return Ok(value);
        //}

        //[HttpGet("BookingStatusApproved")]
        //public IActionResult BookingStatusApproved(int id)
        //{
        //    _bookingService.TBookingStatusApproved(id);
        //    return Ok("Rezervasyon onaylandı");
        //}

        //[HttpGet("BookingStatusCancelled")]
        //public IActionResult BookingStatusCancelled(int id)
        //{
        //    _bookingService.TBookingStatusCancelled(id);
        //    return Ok("Rezervasyon iptal edildi");
        //}

        //[HttpGet("ActiveBookingCount")]
        //public IActionResult ActiveBookingCount()
        //{
        //    var values = _bookingService.TActiveBookingCount();
        //    return Ok(values);
        //}

    }
}
