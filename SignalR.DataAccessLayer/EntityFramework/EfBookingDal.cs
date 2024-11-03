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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveBookingCount()
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Count(x => x.Description == "Rezervasyon Onaylandı");
            return values;
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new SignalRContext();
            var value = context.Bookings.Find(id);
            if (value != null)
            {
                value.Description = "Rezervasyon Onaylandı";
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Rezervasyon Bulunamadı");
            }
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new SignalRContext();
            var value = context.Bookings.Find(id);
            if (value != null)
            {
                value.Description = "Rezervasyon İptal Edildi";
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Rezervasyon Bulunamadı");
            }
        }
    }
}
