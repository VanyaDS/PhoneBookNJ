using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using PhoneRepositoryLibJson;
using PhoneRepositoryLibSql;
using Ninject.Web.Common;


namespace PhoneBookNJ.NJ
{

    public class NinjectRegistrations: NinjectModule
    {
        
        public override void Load()
        {
           
           Bind<IPhoneDictionary<Note>>().To<PhoneDictionary>();                     // объект репозитория создается на новый экземпляр на каждый вызов

          //  Bind<IPhoneDictionary<Note>>().To<PhoneDictionary>().InThreadScope();  //новый экземпляр на каждый поток

           // Bind<IPhoneDictionary<Note>>().To<PhoneDictionary>().InRequestScope(); //новый экземпляр на каждый HTTP-запрос
        }

    }
}