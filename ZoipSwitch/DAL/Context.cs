using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ZoipSwitch.Models;

namespace ZoipSwitch.DAL
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }

        public DbSet<order_status> Order_Statuses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}