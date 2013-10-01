namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePhoneTableAndAddPhonesFieldsToProvider : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "Provider_ID", "dbo.Providers");
            DropIndex("dbo.Phones", new[] { "Provider_ID" });
            AddColumn("dbo.Providers", "Phone1", c => c.String());
            AddColumn("dbo.Providers", "Phone2", c => c.String());
            DropTable("dbo.Phones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        number = c.String(),
                        Provider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Providers", "Phone2");
            DropColumn("dbo.Providers", "Phone1");
            CreateIndex("dbo.Phones", "Provider_ID");
            AddForeignKey("dbo.Phones", "Provider_ID", "dbo.Providers", "ID");
        }
    }
}
