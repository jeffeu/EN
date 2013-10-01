namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryFixit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Providers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Providers", "Adress_ID", "dbo.Adresses");
            DropIndex("dbo.Providers", new[] { "User_ID" });
            DropIndex("dbo.Providers", new[] { "Adress_ID" });
            DropTable("dbo.Providers");
            DropTable("dbo.Adresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        Street = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(),
                        Type = c.String(),
                        Site = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        User_ID = c.Int(),
                        Adress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Providers", "Adress_ID");
            CreateIndex("dbo.Providers", "User_ID");
            AddForeignKey("dbo.Providers", "Adress_ID", "dbo.Adresses", "ID");
            AddForeignKey("dbo.Providers", "User_ID", "dbo.Users", "ID");
        }
    }
}
