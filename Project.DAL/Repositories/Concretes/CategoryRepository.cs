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
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {

        public CategoryRepository(MyContext db):base(db)
        {

        }

        /// <summary>
        /// Dikkat edin bu metot 3 tane default ürünü yarattıgınız kategoriye ekler
        /// </summary>
        /// <param name="category"></param>
        public void SpecialCategoryCreation(Category category)
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    ProductName = "Tadelle",
                    UnitPrice = 12.34M
                },
                  new Product
                {
                    ProductName = "Cizi",
                    UnitPrice = 12.34M
                },
                    new Product
                {
                    ProductName = "Biskrem",
                    UnitPrice = 12.34M
                },
            };


            category.Products = products;

            Add(category);
        }
    }
}
