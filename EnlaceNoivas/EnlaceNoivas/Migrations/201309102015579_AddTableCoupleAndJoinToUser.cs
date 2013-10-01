namespace EnlaceNoivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCoupleAndJoinToUser : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Couple_Id", c => c.String(maxLength: 128));
            AddForeignKey("dbo.Users", "Couple_Id", "dbo.Couples", "Id");
            CreateIndex("dbo.Users", "Couple_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Couple_Id" });
            DropForeignKey("dbo.Users", "Couple_Id", "dbo.Couples");
            DropColumn("dbo.Users", "Couple_Id");
            DropTable("dbo.Couples");
        }
    }
}
