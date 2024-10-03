namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetInfoes",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        BudgetItem = c.String(nullable: false, maxLength: 100, unicode: false),
                        EstimatedCost = c.Double(nullable: false),
                        CreateAt = c.String(nullable: false, maxLength: 50, unicode: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetId)
                .ForeignKey("dbo.TripInfoes", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.TripInfoes",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false, maxLength: 100, unicode: false),
                        StartDate = c.String(nullable: false, maxLength: 50, unicode: false),
                        EndDate = c.String(nullable: false, maxLength: 50, unicode: false),
                        Itinerary = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreateAt = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserId = c.Int(nullable: false),
                        TripShareInfo_ShareId = c.Int(),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.TripShareInfoes", t => t.TripShareInfo_ShareId)
                .ForeignKey("dbo.UserInfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TripShareInfo_ShareId);
            
            CreateTable(
                "dbo.PackingInfoes",
                c => new
                    {
                        CheckListId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 250, unicode: false),
                        IsPacked = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false, maxLength: 50, unicode: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckListId)
                .ForeignKey("dbo.TripInfoes", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.TripShareInfoes",
                c => new
                    {
                        ShareId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false, maxLength: 50, unicode: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShareId)
                .ForeignKey("dbo.TripInfoes", t => t.TripId)
                .ForeignKey("dbo.UserInfoes", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 25, unicode: false),
                        CreatedAt = c.String(nullable: false, maxLength: 50, unicode: false),
                        TripShareInfo_ShareId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.TripShareInfoes", t => t.TripShareInfo_ShareId)
                .Index(t => t.TripShareInfo_ShareId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetInfoes", "TripId", "dbo.TripInfoes");
            DropForeignKey("dbo.TripInfoes", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.UserInfoes", "TripShareInfo_ShareId", "dbo.TripShareInfoes");
            DropForeignKey("dbo.TripShareInfoes", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.TripInfoes", "TripShareInfo_ShareId", "dbo.TripShareInfoes");
            DropForeignKey("dbo.TripShareInfoes", "TripId", "dbo.TripInfoes");
            DropForeignKey("dbo.PackingInfoes", "TripId", "dbo.TripInfoes");
            DropIndex("dbo.UserInfoes", new[] { "TripShareInfo_ShareId" });
            DropIndex("dbo.TripShareInfoes", new[] { "TripId" });
            DropIndex("dbo.TripShareInfoes", new[] { "UserId" });
            DropIndex("dbo.PackingInfoes", new[] { "TripId" });
            DropIndex("dbo.TripInfoes", new[] { "TripShareInfo_ShareId" });
            DropIndex("dbo.TripInfoes", new[] { "UserId" });
            DropIndex("dbo.BudgetInfoes", new[] { "TripId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.TripShareInfoes");
            DropTable("dbo.PackingInfoes");
            DropTable("dbo.TripInfoes");
            DropTable("dbo.BudgetInfoes");
        }
    }
}
