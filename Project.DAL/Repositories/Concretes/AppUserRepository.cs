using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {

        //Sizin kendinize özel CRUD işlemlerinizin yine olması gerekir...ANcak unutmayın ki Identity yapısının özel şifrelemeler ve yetkilendirmeleri icin hazır async(bir işlem duraksadıgında diger işlemleri bekletmeyen) metotları vardır... BU metotların kullanımı icin de ekstra olarak bu Repository'de ayrı metotlar acmak en dogrusudur... Bu metotlar Manager sınıfları icerisinde bulundurulur(UserManager,SignInManager Identity'de gömülü olan sınıflardır) Bu sınıflar Dependency Injection ile calısırlar...Dolayısıyla Constructor Based Injection yapılabilir...


        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AppUserRepository(MyContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        //Identity Metotları async seklinde tanımlanmıslardır...Yani bu metotlar ayrık işlem yapabilme kabiliyetine sahiplerdir...Bunun nedeni, siz bir API kullandıgınızda bu requestlerin bloklanmadan devam edebilmesini isterseniz...İşlemleri tamamlayarak hatasız bir şekilde akıcı olması adına da await keyword'unun kullanılması gerekir...Cünkü bu keyword kullanılmazsa , metodunuz async metot olmasına rağmen program oradan verinin gec gelebilecegini algılayamayarak sanki veri hemen geliyormus gibi düsünür ve verinin gec gelecegi senaryoda da veriyi alamayacagından dolayı o veriyi null olarak elde edersiniz...

        //Calısma yaptıgınız metot icerisinde await keyword'unun kullanılabilmesi icin calısma yaptıgınız metodun async seklinde tanımlanması gerekir ve Task ile deger döndürmesi gerekir...

        //Await keyword'u aynı zamanda Task icerisindeki tipi bana direkt olarak döndürür


        public async Task<bool> AddUser(AppUser item)
        {
            //Sadece Asenkron olarak yaratılmıs(async marklı) metotlar icerisinde await keyword'unu kullanabilirsiniz

            //CreateAsync metodu normal şartlarda bize Task<IdentityResult> döndürür...Lakin await keyword'u ile bu metodu cagırırsak o zaman Task icerisindeki IdentityResult direkt döner... 

            //CreateAsync metodu ile veritabanına Identity sayesinde kullanıcınızı eklersiniz


            IdentityResult result =await  _userManager.CreateAsync(item,item.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(item,isPersistent:false); //isPersistance durumu Cookie'de dursun mu durmasın mı bunu belirtir...
                return true;
            }

            return false;
        }
    }
}


/*
 
 
 bool result =await Login();
 
 
 
 */