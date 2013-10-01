namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 40),
                        pass = c.String(nullable: false, maxLength: 40),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
