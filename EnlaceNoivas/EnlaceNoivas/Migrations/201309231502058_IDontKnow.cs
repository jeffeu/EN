namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDontKnow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Type = c.String(),
                        Site = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        city = c.String(),
                        Street = c.String(),
                        number = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Providers", new[] { "User_ID" });
            DropForeignKey("dbo.Providers", "User_ID", "dbo.Users");
            DropTable("dbo.Providers");
        }
    }
}
