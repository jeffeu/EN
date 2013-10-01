namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryDoItHappen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "Pass", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "pass", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
