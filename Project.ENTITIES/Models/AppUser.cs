using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    //BUrada miras aldıgımız sınıf bir Identity sınıfıdır...Identity'deki User tablosunun kendisini temsil eder biz oradan miras olarak normalde orada olusacak özellikleri de kendi AppUser sınıfımıza aktarıyoruz ve aslında Identity'de User'a müdahale ediyoruz...Generic'teki int ifadesi ise primary key'imiz Identity'de int olacagını bildirir...
    public class AppUser:IdentityUser<int>,IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }




    }
}
