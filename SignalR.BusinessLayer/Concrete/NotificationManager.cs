using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetNotificationListByFalse()
        {
            return _notificationDal.GetNotificationListByFalse();
        }

        public Notification TGetByID(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll().OrderByDescending(x => x.NotificationID).ToList(); 
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }

        public void TUpdateNotificationStatusTrue(int id)
        {
            _notificationDal.UpdateNotificationStatusTrue(id);
        }

        public void TUpdateNotificationStatusFalse(int id)
        {
            _notificationDal.UpdateNotificationStatusFalse(id);
        }
    }
}
