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

        public DbSet<case_statuses> Case_Statuses { get; set; }
        public DbSet<case_types> Case_Types { get; set; }
        public DbSet<case_urgencies> Case_Urgencies { get; set; }
        public DbSet<case_departments> Case_Departments { get; set; }
        public DbSet<action_categories> Action_Categories { get; set; }
        public DbSet<action_types> Action_Types { get; set; }
        public DbSet<action_statuses> Action_Statuses { get; set; }
        public DbSet<operators> Operators { get; set; }
        public DbSet<agents> Agents { get; set; }
        public DbSet<actions> Actions { get; set; }
        public DbSet<cases> Cases { get; set; }

        public DbSet<vwAction> VwAction { get; set; }
        public DbSet<vwCases> VwCases { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}