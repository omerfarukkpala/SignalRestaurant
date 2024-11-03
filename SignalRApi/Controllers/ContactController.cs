using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("İletişim Bilgisi Eklendi");



            //_contactService.TAdd(new Contact()
            //{
            //    FooterDescription = createContactDto.FooterDescription,
            //    Location = createContactDto.Location,
            //    Mail = createContactDto.Mail,
            //    Phone = createContactDto.Phone,
            //    FooterTitle = createContactDto.FooterTitle,
            //    OpenDays = createContactDto.OpenDays,
            //    OpenHours = createContactDto.OpenHours,
            //    OpenDaysDescription = createContactDto.OpenDaysDescription
            //});
            //return Ok("İletişim bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi silindi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {

            var value = _contactService.TGetByID(id);
            return Ok(_mapper.Map<GetContactDto>(value));

            //var value = _contactService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İletişim Bilgisi Güncellendi");


            //_contactService.TUpdate(new Contact()
            //{
            //    ContactID = updateContactDto.ContactID,
            //    FooterDescription = updateContactDto.FooterDescription,
            //    Location = updateContactDto.Location,
            //    Mail = updateContactDto.Mail,
            //    Phone = updateContactDto.Phone,
            //    FooterTitle = updateContactDto.FooterTitle,
            //    OpenDays = updateContactDto.OpenDays,
            //    OpenHours = updateContactDto.OpenHours,
            //    OpenDaysDescription = updateContactDto.OpenDaysDescription
            //});
            //return Ok("İletişim bilgisi güncellendi");
        }
    }
}
