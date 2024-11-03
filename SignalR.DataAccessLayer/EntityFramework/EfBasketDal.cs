using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableDetailID(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.TableDetailID == id).Include(y => y.Product).ToList();
            return values;

        }

        public List<ResultBasketListWithProducts> GetBasketListByTableDetailWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.TableDetailID == id).Include(y => y.Product).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                Price = z.Product.Price,
                Count = z.Count,
                TotalPrice = z.TotalPrice,
                ProductID = z.ProductID,
                TableDetailID = z.TableDetailID,
                ProductName = z.Product.ProductName
            }).ToList();

            return values;
        }
    }
}
