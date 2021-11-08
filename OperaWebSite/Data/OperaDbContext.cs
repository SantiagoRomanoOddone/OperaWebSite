using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // A
using OperaWebSite.Data; //a
using OperaWebSite.Models;//a

namespace OperaWebSite.Data
{
    //AGREG dBcONTEXT
    public class OperaDbContext : DbContext
    {
        public OperaDbContext() : base("KeyDB") { }
        public DbSet<Opera> Operas { get; set; }
    }

}