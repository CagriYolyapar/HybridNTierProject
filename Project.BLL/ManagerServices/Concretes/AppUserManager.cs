using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserManager:BaseManager<AppUser>,IAppUserManager
    {
        IAppUserRepository _appRep;
        public AppUserManager(IAppUserRepository ap):base(ap)
        {
            _appRep = ap;
        }

        public  async Task<bool> AddUser(AppUser item)
        {
            //Todo:Business logic işlemleri 
            return await _appRep.AddUser(item);
        }
    }
}
