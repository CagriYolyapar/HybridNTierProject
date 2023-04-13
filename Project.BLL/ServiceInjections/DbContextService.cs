using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    //DbContextPool'umuz böylece StartUp'da DAL'den bir sınıfı kullanmaktan ziyade sadece BLL'deki bu ifadelerle bir Service entegrasyonu (middleware'de) yapacaktır...
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider(); 

            //Sakın IConfiguration kullanırken Castle kütüphanesini kullanmayın...Kullanacagınız kütüphane Microsoft.Extensions.Configuration olmak zorundadır...
            IConfiguration? configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;
        }
    }
}
