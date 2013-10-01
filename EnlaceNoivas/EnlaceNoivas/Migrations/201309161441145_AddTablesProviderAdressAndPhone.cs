namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesProviderAdressAndPhone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adresses", t => t.Adress_ID)
                .Index(t => t.Adress_ID);
            
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
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        number = c.String(),
                        Provider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Providers", t => t.Provider_ID)
                .Index(t => t.Provider_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Phones", new[] { "Provider_ID" });
            DropIndex("dbo.Providers", new[] { "Adress_ID" });
            DropForeignKey("dbo.Phones", "Provider_ID", "dbo.Providers");
            DropForeignKey("dbo.Providers", "Adress_ID", "dbo.Adresses");
            DropTable("dbo.Phones");
            DropTable("dbo.Adresses");
            DropTable("dbo.Providers");
        }
    }
}
