namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCoupleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Couples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrideName = c.String(),
                        GroomName = c.String(),
                        MerriedDate = c.DateTime(nullable: false),
                        CoupleUrl = c.String(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Couples", new[] { "User_ID" });
            DropForeignKey("dbo.Couples", "User_ID", "dbo.Users");
            DropTable("dbo.Couples");
        }
    }
}
