﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public int NotificationID { get; set; }
        public string? NotificationType { get; set; }
        public string? NotificationIcon { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
