namespace Breakfast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsSettings",
                c => new
                    {
                        Pk_NewsId = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_NewsId);
            
            CreateTable(
                "dbo.SettingsTable",
                c => new
                    {
                        Pk_Email = c.String(nullable: false, maxLength: 128),
                        Fk_NewsId = c.Int(nullable: false),
                        Fk_TrafficId = c.Int(nullable: false),
                        Fk_WeatherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Email)
                .ForeignKey("dbo.NewsSettings", t => t.Fk_NewsId, cascadeDelete: true)
                .ForeignKey("dbo.TrafficSettings", t => t.Fk_TrafficId, cascadeDelete: true)
                .ForeignKey("dbo.WeatherSettings", t => t.Fk_WeatherId, cascadeDelete: true)
                .Index(t => t.Fk_NewsId)
                .Index(t => t.Fk_TrafficId)
                .Index(t => t.Fk_WeatherId);
            
            CreateTable(
                "dbo.TrafficSettings",
                c => new
                    {
                        Pk_TrafficId = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        Address = c.String(),
                        WorkAddress = c.String(),
                        TravelMode = c.String(),
                        AddressPlaceId = c.String(),
                        WorkAddressPlaceId = c.String(),
                    })
                .PrimaryKey(t => t.Pk_TrafficId);
            
            CreateTable(
                "dbo.WeatherSettings",
                c => new
                    {
                        Pk_WeatherId = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        Farenheit = c.Boolean(nullable: false),
                        WindSpeed = c.Boolean(nullable: false),
                        Humidity = c.Boolean(nullable: false),
                        Cloudiness = c.Boolean(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Pk_WeatherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SettingsTable", "Fk_WeatherId", "dbo.WeatherSettings");
            DropForeignKey("dbo.SettingsTable", "Fk_TrafficId", "dbo.TrafficSettings");
            DropForeignKey("dbo.SettingsTable", "Fk_NewsId", "dbo.NewsSettings");
            DropIndex("dbo.SettingsTable", new[] { "Fk_WeatherId" });
            DropIndex("dbo.SettingsTable", new[] { "Fk_TrafficId" });
            DropIndex("dbo.SettingsTable", new[] { "Fk_NewsId" });
            DropTable("dbo.WeatherSettings");
            DropTable("dbo.TrafficSettings");
            DropTable("dbo.SettingsTable");
            DropTable("dbo.NewsSettings");
        }
    }
}
