using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);  
        }

        public List<Basket> TGetBasketByTableDetailID(int id)
        {
            return _basketDal.GetBasketByTableDetailID(id);
        }

        public List<ResultBasketListWithProducts> TGetBasketListByTableDetailWithProductName(int id)
        {
            return _basketDal.GetBasketListByTableDetailWithProductName(id);
        }

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
