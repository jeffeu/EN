namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImageName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Providers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Providers", "image", c => c.String());
        }
    }
}
