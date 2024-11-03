using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByTableDetailID(int id);
        List<ResultBasketListWithProducts> GetBasketListByTableDetailWithProductName(int id);
    }
}
