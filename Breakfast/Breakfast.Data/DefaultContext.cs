using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Breakfast.Data
{
    class DefaultContext : DbContext
    {
        public DefaultContext() : base("Default")
        {
        }

        public DbSet<Models.SettingsTable> SettingsTable { get; set; }
        public DbSet<Models.NewsSettings> NewsSettings { get; set; }
        public DbSet<Models.TrafficSettings> TrafficSettings { get; set; }
        public DbSet<Models.WeatherSettings> WeatherSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
