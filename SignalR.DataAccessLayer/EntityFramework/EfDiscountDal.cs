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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void DiscountStatusChangeFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Discounts.Find(id);
            if (value != null)
            {
                value.Status = false;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("İndirim bulunamadı");
            }
        }

        public void DiscountStatusChangeTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Discounts.Find(id);
            if (value != null)
            {
                value.Status = true;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("İndirim bulunamadı");
            }
        }

        public List<Discount> GetDiscountListByStatusTrue()
        {
            using var context = new SignalRContext();
            var value = context.Discounts.Where(x => x.Status == true).ToList();
            return value;
        }
    }
}
