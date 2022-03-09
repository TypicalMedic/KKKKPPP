using KKKKPPP.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKKKPPP.Data
{
    public class DBObjects
    {
        /// <summary>
        /// добавляет объект в бд?
        /// </summary>
        /// <param name="app"></param>
        public static void Initial(AppDBContext context)
        {
            //при запуске сайта (КАЖДЫЙ РАЗ потому что мы ее так вызывем) эта штука смотрит, пустые ли таблицы и если да то добавляет туда список элементов, перечисленных ниже
            //if (context.Автор.Any())
            //{
            //  //  context.Cnt.AddRange(Countries.Select(c => c.Value));
            //    foreach(var x in context.Автор)
            //    {
            //        string a = x.ФИО;
            //    }
            //}

            //if (!content.Pt.Any())
            //{
            //    content.Pt.AddRange(
            //        new Painting
            //        {
            //            name = "Abc",
            //            isExposed = true,
            //            year = 1900,
            //            img = "/img/21dsf.jpg",
            //            drawnCountry = Countries["Russia"]
            //        },
            //        new Painting
            //        {
            //            name = "Xyz",
            //            isExposed = false,
            //            year = 1999,
            //            drawnCountry = Countries["USA"]
            //        }
            //        );
            //}
            // content.SaveChanges();
        }
        
    }
}
