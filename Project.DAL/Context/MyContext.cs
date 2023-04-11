using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using Project.MAP.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    //Eger kurmak istediginiz Veritabanı yapısında Identity kullanacaksanız DbContext'ten miras alamazsınız...Cünkü Identity , kendi tablolarını tamamen hazır bir yapı olarak sunabilmesi adına sizi IdentityDbContext'ten miras almaya yönlendirir...

    //Identity normal şartlarda tablolarını temsil edecek classlar'a sahip olsa da bu tabloların primary keylerinin hangi tipte olacagını bilmez siz bir ifadede bulunmazsanız da gider primary key'lerini nvarchar acar(burada string olarak görür default olarak)...O yüzden siz eger özellikle bir domain entity'inize bir Identity sınıfından miras vererek actıysanız bu demektir ki Identity ile sizin özellikleriniz birleşiyor (bkz. AppUser)...Dolayısıyla bu sınıf generic olarak IdentityDbContext sınıfının ilk generic argümanı olarak verilebilir... Ancak eger Identity'nin kendi sınıfını kullanmasına izin veriyorsanız (bkz. IdentityRole) generic olarak ona pk'in hangi tipte olacagını söylemelisiniz...
    public class MyContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProfileConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }
    }
}
