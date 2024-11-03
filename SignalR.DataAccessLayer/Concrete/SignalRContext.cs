using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMERFARUKPALA; initial catalog=PalaSignalRDb; integrated security=true;");
        }

        public DbSet<About> Abouts { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Discount> Discounts { get; set; } = null!;
        public DbSet<Feature> Features { get; set; }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<SocialMedia> SocialMedias { get; set; } = null!;
        public DbSet<Testimonial> Testimonials { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<MoneyCase> MoneyCases { get; set; } = null!;
        public DbSet<MenuTable> MenuTables { get; set; }

        public DbSet<TableDetail> TableDetails { get; set; } = null!;
        public DbSet<Slider> Sliders { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;

    }
}
