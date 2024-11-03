using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;


        public MessageController(IMessageService messageService , IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));

            //return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.MessageSendDate = DateTime.Now;
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");

            //Message message = new Message()
            //{
            //    NameSurname = createMessageDto.NameSurname,
            //    Mail = createMessageDto.Mail,
            //    Phone = createMessageDto.Phone,
            //    Subject = createMessageDto.Subject,
            //    MessageContent = createMessageDto.MessageContent,
            //    MessageSendDate = DateTime.Now,
            //    Status = false
            //};

            //_messageService.TAdd(message);
            //return Ok("Mesaj başarılı bir şekilde gönderildi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {

            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesaj Bilgisi Güncellendi");

            //Message message = new Message()
            //{
            //    MessageID = updateMessageDto.MessageID,
            //    Mail = updateMessageDto.Mail,
            //    MessageContent = updateMessageDto.MessageContent,
            //    MessageSendDate = updateMessageDto.MessageSendDate,
            //    NameSurname = updateMessageDto.NameSurname,
            //    Phone = updateMessageDto.Phone,
            //    Status = updateMessageDto.Status,
            //};
            //_messageService.TUpdate(message);
            //return Ok("Mesaj başarılı bir şekilde güncellendi");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));

            //return Ok(value);
        }

        [HttpGet("ChangeMessageStatusTrue")]
        public IActionResult ChangeMessageStatusTrue(int id)
        {
            _messageService.TChangeMessageStatusTrue(id);
            return Ok("Mesaj başarılı bir şekilde okundu");
        }

        [HttpGet("ChangeMessageStatusFalse")]
        public IActionResult ChangeMessageStatusFalse(int id)
        {
            _messageService.TChangeMessageStatusFalse(id);
            return Ok("Mesaj başarılı bir şekilde okunmadı");
        }

        [HttpGet("MessageCountByStatusFalse")]
        public IActionResult MessageCountByStatusFalse()
        {
            var value = _messageService.TMessageCountByStatusFalse();
            return Ok(value);
        }
    }
}
