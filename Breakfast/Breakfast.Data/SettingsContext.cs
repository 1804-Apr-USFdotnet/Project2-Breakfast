using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Breakfast.Data
{
    class SettingsContext : DbContext, IContext
    {
        public SettingsContext() : base("Default")
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
