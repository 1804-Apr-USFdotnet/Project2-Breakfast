using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Data
{
    class SettingsContext : DbContext
    {
        public SettingsContext() : base("SettingsContext")
        {
        }

        public DbSet<Models.SettingsTable> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
