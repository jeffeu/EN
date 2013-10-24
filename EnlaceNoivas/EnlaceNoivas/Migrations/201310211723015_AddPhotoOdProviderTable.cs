namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoOdProviderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhotoOfProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        provider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.provider_ID)
                .Index(t => t.provider_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PhotoOfProviders", new[] { "provider_ID" });
            DropForeignKey("dbo.PhotoOfProviders", "provider_ID", "dbo.Providers");
            DropTable("dbo.PhotoOfProviders");
        }
    }
}
