using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DamaoJetty.Web.Models
{
    public class DamaoJettyContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
    }

}