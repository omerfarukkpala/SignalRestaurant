using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetNotificationListByFalse()
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Where(x => x.Status == false).OrderByDescending(x => x.NotificationID).ToList(); 
            return values;
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Where(x => x.Status == false).Count();
            return values;
        }

        public void UpdateNotificationStatusTrue(int id)
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Find(id);
            values.Status = true;
            context.SaveChanges();
        }

        public void UpdateNotificationStatusFalse(int id)
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        
    }
}
