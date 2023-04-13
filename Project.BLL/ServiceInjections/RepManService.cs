using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepManService
    {

        public static IServiceCollection AddRepManServices(this IServiceCollection services)
        {
            //Repositories , Managers

            //Scoped, Transient, Singleton

            /*
             
             Scoped : Bir Request'te Scope'un parametre kümesinde aynı tipte birden fazla parametre gelse bile 1 instance üzerinden calısırsınız...Ancak bu Singleton degildir...Cünkü Request'in işi bittigi zaman Garbage Collector Ram'den o instance'i kaldırır...Bir Request'in scope'unda aynı tipte birden fazla instance Repositoryler ve Managerlar icin anlamsızdır...O yüzden Scoped tercih edilir...


            Transient : Bir Request'in ulastıgı Scope'un parametre kümesinde aynı tipten kac tane varsa o kadar instance alınır...Manager ve Repositoryler icin anlamsızdır...Cünkü bunlardan bir tanesi bir Request'teki scope icin yeterlidir...



            Singleton : Bir Request'in ulastıgı Scope'un parametre kümesinde bir tip görüldügü anda instance alınır ve program kapanıncaya kadar o instance'tan devam edilir...Manager ve Repositoryler icin anlamsızdır...
             
             
             
             
             
             
             */
           

            services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));

            services.AddScoped<IProductRepository,ProductRepository>(); 
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderDetailRepository,OrderDetailRepository>(); 
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IAppUserRepository,AppUserRepository>();   
            services.AddScoped<IProfileRepository,ProfileRepository>();


            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IProductManager,ProductManager>();
            services.AddScoped<IOrderManager,OrderManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();   
            services.AddScoped<IAppUserManager,AppUserManager>();   
            services.AddScoped<IProfileManager,ProfileManager>();

            return services;
            
        }


     
    }
}
