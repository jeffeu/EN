namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteCouple : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Couples", "User_ID", "dbo.Users");
            DropIndex("dbo.Couples", new[] { "User_ID" });
            DropTable("dbo.Couples");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Couples",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GroomName = c.String(),
                        BrideName = c.String(),
                        CoupleUrl = c.String(),
                        MerriedDate = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Couples", "User_ID");
            AddForeignKey("dbo.Couples", "User_ID", "dbo.Users", "ID");
        }
    }
}
