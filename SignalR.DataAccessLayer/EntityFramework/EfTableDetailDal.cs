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
    public class EfTableDetailDal : GenericRepository<TableDetail>, ITableDetailDal
    {
        public EfTableDetailDal(SignalRContext context) : base(context)
        {
        }

        public int TableCount()
        {
            using var context = new SignalRContext();
            return context.TableDetails.Count();
        }
    }
}
