using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "Yerel Ürünler").Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "Meşrubatlar").Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderByDescending(x => x.Price).FirstOrDefault().ProductName;
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderBy(x => x.Price).FirstOrDefault().ProductName;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "Özel Tatlılar").Average(x => x.Price);
        }


        public List<Product> GetLast6Product()
        {
            var context = new SignalRContext();
            var values = context.Products.Take(6).ToList();
            return values;
        }
    }
}
