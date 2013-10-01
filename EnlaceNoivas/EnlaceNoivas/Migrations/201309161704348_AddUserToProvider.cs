namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "User_ID", c => c.Int());
            AddForeignKey("dbo.Providers", "User_ID", "dbo.Users", "ID");
            CreateIndex("dbo.Providers", "User_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Providers", new[] { "User_ID" });
            DropForeignKey("dbo.Providers", "User_ID", "dbo.Users");
            DropColumn("dbo.Providers", "User_ID");
        }
    }
}
