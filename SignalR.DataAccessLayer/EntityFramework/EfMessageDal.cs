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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeMessageStatusFalse(int id)
        {
            using var context = new SignalRContext();
            var message = context.Messages.Find(id);
            if (message != null)
            {
                message.Status = false;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Mesaj bulunamadı");
            }

        }

        public void ChangeMessageStatusTrue(int id)
        {
            using var context = new SignalRContext();
            var message = context.Messages.Find(id);
            if (message != null)
            {
                message.Status = true;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Mesaj bulunamadı");
            }
        }

        public int MessageCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var values = context.Messages.Where(x => x.Status == false).Count();
            return values;
        }
    }
}
