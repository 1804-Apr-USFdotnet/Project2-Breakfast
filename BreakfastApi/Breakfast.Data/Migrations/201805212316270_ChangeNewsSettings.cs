namespace Breakfast.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNewsSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsSettings", "QueryStrings", c => c.String());
            AddColumn("dbo.NewsSettings", "Sources", c => c.String());
            AddColumn("dbo.NewsSettings", "Domains", c => c.String());
            AddColumn("dbo.NewsSettings", "Language", c => c.String());
            AddColumn("dbo.NewsSettings", "PageSize", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsSettings", "PageSize");
            DropColumn("dbo.NewsSettings", "Language");
            DropColumn("dbo.NewsSettings", "Domains");
            DropColumn("dbo.NewsSettings", "Sources");
            DropColumn("dbo.NewsSettings", "QueryStrings");
        }
    }
}
