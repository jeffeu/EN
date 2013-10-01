namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFKFromCoupleToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Couple_Id", "dbo.Couples");
            DropIndex("dbo.Users", new[] { "Couple_Id" });
            AddColumn("dbo.Couples", "User_ID", c => c.Int());
            AddForeignKey("dbo.Couples", "User_ID", "dbo.Users", "ID");
            CreateIndex("dbo.Couples", "User_ID");
            DropColumn("dbo.Users", "Couple_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Couple_Id", c => c.String(maxLength: 128));
            DropIndex("dbo.Couples", new[] { "User_ID" });
            DropForeignKey("dbo.Couples", "User_ID", "dbo.Users");
            DropColumn("dbo.Couples", "User_ID");
            CreateIndex("dbo.Users", "Couple_Id");
            AddForeignKey("dbo.Users", "Couple_Id", "dbo.Couples", "Id");
        }
    }
}
