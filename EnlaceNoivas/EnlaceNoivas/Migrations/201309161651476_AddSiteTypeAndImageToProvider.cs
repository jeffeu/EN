namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSiteTypeAndImageToProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "image", c => c.String());
            AddColumn("dbo.Providers", "Type", c => c.String());
            AddColumn("dbo.Providers", "Site", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "Site");
            DropColumn("dbo.Providers", "Type");
            DropColumn("dbo.Providers", "image");
        }
    }
}
