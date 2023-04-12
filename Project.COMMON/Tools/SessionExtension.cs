using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class SessionExtension
    {
        //Serialization => Bir yapının Json formata dönüstürülmesidir...

        //Deserialization => Json formatındaki bir bilginin ilgili yapıya dönüstürülmesidir

        //Session["scart"] = c;


        //Extension Metotlar sadece static sınıflarda yaratılabilir...Bir metot this ile parametre almazsa o zaman o klasik bir metot olur...Kısacası bir Extension metot hangi tipin icerisine gömülecek ise o tipi this keyword'u ile almak zorundadır...Bizim burada bu metotları entegre etmek istedigimiz tip ISession tipidir...

        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value); //BUrada bize gelen object degeri JSON formatta bir string'e cevirdik...

            session.SetString(key,objectString);

        }


        //ISession i 
        //i.SetObject("scart",c)

        //Session'u geri almak lazım...


        public static T GetObject<T>(this ISession session,string key) 
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString)) throw new Exception("Session nesnesi bulunamadı");
            T deserializedObject = JsonConvert.DeserializeObject<T>(objectString);
            return deserializedObject;
        }








    }
}
