using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void SpecialCategoryCreation(Category category); //Kategori eklendiginde default en az 3 Urun eklesin...
        
    }
}
