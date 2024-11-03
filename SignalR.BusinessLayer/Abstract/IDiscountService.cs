using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TDiscountStatusChangeTrue(int id);
        void TDiscountStatusChangeFalse(int id);
        List<Discount> TGetDiscountListByStatusTrue();
    }
}
