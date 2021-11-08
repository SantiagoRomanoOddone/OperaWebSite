﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //A
using OperaWebSite.Models;//a

namespace OperaWebSite.Data
{
    public class OperasInitializer : DropCreateDatabaseAlways<OperaDbContext>
    {
        //protected override void Seed(OperaDbContext context)
        //{
        //    base.Seed(context);
        //}

        //esto sería el polimorfismo
        protected override void Seed(OperaDbContext context)
        {
            var operas = new List<Opera>
            {
               new Opera {
                  Title = "Cosi Fan Tutte",
                  Year = 1790,
                  Composer = "Mozart"
               }
            };
            operas.ForEach(s => context.Operas.Add(s));
            context.SaveChanges();


        }
    }

}