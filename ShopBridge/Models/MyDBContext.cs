using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Items> Items { get; set; }
    }
}