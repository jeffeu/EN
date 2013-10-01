namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSomeFieldsName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Providers", "City", c => c.String());
            AlterColumn("dbo.Providers", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Providers", "number", c => c.Int(nullable: false));
            AlterColumn("dbo.Providers", "city", c => c.String());
        }
    }
}
