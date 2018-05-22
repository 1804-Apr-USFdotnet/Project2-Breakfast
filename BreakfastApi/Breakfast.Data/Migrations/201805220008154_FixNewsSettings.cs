namespace Breakfast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNewsSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsSettings", "Queries", c => c.String());
            AddColumn("dbo.NewsSettings", "OldestDate", c => c.DateTime());
            AddColumn("dbo.NewsSettings", "NewestDate", c => c.DateTime());
            DropColumn("dbo.NewsSettings", "QueryStrings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsSettings", "QueryStrings", c => c.String());
            DropColumn("dbo.NewsSettings", "NewestDate");
            DropColumn("dbo.NewsSettings", "OldestDate");
            DropColumn("dbo.NewsSettings", "Queries");
        }
    }
}
