using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;


        public NotificationController(INotificationService notificationService , IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));

            //return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {

            createNotificationDto.Status = false;
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Ekleme işlemi başarıyla yapıldı");


            //Notification notification = new Notification
            //{
            //    NotificationType = createNotificationDto.NotificationType,
            //    NotificationIcon = createNotificationDto.NotificationIcon,
            //    Description = createNotificationDto.Description,
            //    Date = DateTime.Now,
            //    Status = false
            //};
            //_notificationService.TAdd(notification);
            //return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silindi");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdNotificationDto>(values));

            //return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {

            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Güncelleme işlemi başarıyla yapıldı");

            //Notification notification = new Notification
            //{
            //    NotificationID = updateNotificationDto.NotificationID,
            //    NotificationType = updateNotificationDto.NotificationType,
            //    NotificationIcon = updateNotificationDto.NotificationIcon,
            //    Description = updateNotificationDto.Description,
            //    Date = updateNotificationDto.Date,
            //    Status = updateNotificationDto.Status
            //};
            //_notificationService.TUpdate(notification);
            //return Ok("Güncelleme işlemi başarıyla yapıldı");
        }

        [HttpGet("GetNotificationListByFalse")]
        public IActionResult GetNotificationListByFalse()
        {
            var values = _notificationService.TGetNotificationListByFalse();
            return Ok(values);
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            return Ok(values);
        }

        [HttpGet("UpdateNotificationStatusTrue")]
        public IActionResult UpdateNotificationStatusTrue(int id)
        {
            _notificationService.TUpdateNotificationStatusTrue(id);
            return Ok("Bildirim güncellendi");
        }

        [HttpGet("UpdateNotificationStatusFalse")]
        public IActionResult UpdateNotificationStatusFalse(int id)
        {
            _notificationService.TUpdateNotificationStatusFalse(id);
            return Ok("Bildirim güncellendi");
        }
    }
}
