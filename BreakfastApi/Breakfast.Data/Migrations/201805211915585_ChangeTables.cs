namespace Breakfast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrafficSettings", "Driving", c => c.Boolean(nullable: false));
            DropColumn("dbo.TrafficSettings", "TravelMode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrafficSettings", "TravelMode", c => c.String());
            DropColumn("dbo.TrafficSettings", "Driving");
        }
    }
}
