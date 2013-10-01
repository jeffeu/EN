namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isanychange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "codetoactive", c => c.String());
            AddColumn("dbo.Users", "Actived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Actived");
            DropColumn("dbo.Users", "codetoactive");
        }
    }
}
