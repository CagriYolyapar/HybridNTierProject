using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{

    //Abstract olmamasının ciddi bir nedeni
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _iRep;



        public BaseManager(IRepository<T> iRep)
        {

            _iRep = iRep;
        }

        public string Add(T item)
        {
            if (item.CreatedDate != null)
            {
                _iRep.Add(item);
                return "Ekleme basarılıdır";
            }

            return "Ekleme tarihi kısmında bir sorunla karsılasıldı";

        }

        public string AddRange(List<T> list)
        {
            if(list.Count > 5)
            {
                return "Maksimum 5 veri ekleyebileceginiz icin işlem gercekleştirilmedi";
            }
            _iRep.AddRange(list);
            return "Ekleme durumu basarılı bir şekilde gerçekleşti";
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            //exp kontrol işlemleri 
            return _iRep.Any(exp);
        }

        public void Delete(T item)
        {
            _iRep.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _iRep.DeleteRange(list);
        }

        public string Destroy(T item)
        {
            if(item.Status != ENTITIES.Enums.DataStatus.Deleted)
            {
                return "Bir veriyi yok etmek icin öncelikle onun Passive hale getirildiginden emin olmanız gerkeir...";
            }


            _iRep.Destroy(item);
            return "Veri yok edildi";
        }

        public void DestroyRange(List<T> list)
        {
            //Todo: Business logic yapılır

            _iRep.DestroyRange(list);
        }

        public T Find(int id)
        {
            //Todo: Business logic yapılır

            return _iRep.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            //Todo: Business logic yapılır

            return _iRep.FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            //Todo: Business logic yapılır
            return _iRep.GetActives();
        }

        public List<T> GetAll()
        {
            //Todo: Business logic yapılır (DTO maplemesi yapılır...Cünkü size Repository'den Domain Entity gelir...Siz de bunu DTO'ya maplersiniz...

            return _iRep.GetAll();
        }

        public List<T> GetFirstDatas(int count)
        {

            return _iRep.GetFirstDatas(count);
        }

        public List<T> GetLastDatas(int count)
        {
            return _iRep.GetLastDatas(count);
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }

        public object Select(Expression<Func<T, bool>> exp)
        {
            return _iRep.Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public void Update(T item)
        {
            _iRep.Update(item);
        }

        public void UpdateRange(List<T> list)
        {
            _iRep.UpdateRange(list);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }
    }
}
