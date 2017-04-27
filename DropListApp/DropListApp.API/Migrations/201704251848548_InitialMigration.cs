namespace DropListApp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        DroplistId = c.Int(nullable: false),
                        BuildingNumber = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        StockerId = c.Int(nullable: false),
                        EmployeeNumber = c.Int(nullable: false),
                        BuildingName = c.String(),
                        Telephone = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BuildingId)
                .ForeignKey("dbo.users", t => t.user_UserId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmployeeNumber = c.Int(nullable: false),
                        Building_BuildingId = c.Int(),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .ForeignKey("dbo.users", t => t.user_UserId)
                .Index(t => t.Building_BuildingId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.Droplists",
                c => new
                    {
                        DroplistId = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                        StockerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        DroplistName = c.String(),
                        Department = c.String(),
                        IsleNumber = c.Int(nullable: false),
                        IsleRow = c.String(),
                        IsleColumn = c.Int(nullable: false),
                        DroplistDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DroplistId)
                .ForeignKey("dbo.Stockers", t => t.StockerId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.StockerId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Stockers",
                c => new
                    {
                        StockerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmployeeNumber = c.Int(nullable: false),
                        Building_BuildingId = c.Int(),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.StockerId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .ForeignKey("dbo.users", t => t.user_UserId)
                .Index(t => t.Building_BuildingId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmaillAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stockers", "user_UserId", "dbo.users");
            DropForeignKey("dbo.Drivers", "user_UserId", "dbo.users");
            DropForeignKey("dbo.Buildings", "user_UserId", "dbo.users");
            DropForeignKey("dbo.Stockers", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Drivers", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Droplists", "StockerId", "dbo.Stockers");
            DropIndex("dbo.Stockers", new[] { "user_UserId" });
            DropIndex("dbo.Stockers", new[] { "Building_BuildingId" });
            DropIndex("dbo.Droplists", new[] { "DriverId" });
            DropIndex("dbo.Droplists", new[] { "StockerId" });
            DropIndex("dbo.Droplists", new[] { "BuildingId" });
            DropIndex("dbo.Drivers", new[] { "user_UserId" });
            DropIndex("dbo.Drivers", new[] { "Building_BuildingId" });
            DropIndex("dbo.Buildings", new[] { "user_UserId" });
            DropTable("dbo.users");
            DropTable("dbo.Stockers");
            DropTable("dbo.Droplists");
            DropTable("dbo.Drivers");
            DropTable("dbo.Buildings");
        }
    }
}
