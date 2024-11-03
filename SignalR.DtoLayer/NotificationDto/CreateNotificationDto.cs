using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.NotificationDto
{
    public class CreateNotificationDto
    {
        public string? NotificationType { get; set; }
        public string? NotificationIcon { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
