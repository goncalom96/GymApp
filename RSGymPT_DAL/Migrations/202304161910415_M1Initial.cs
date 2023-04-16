namespace RSGymPT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateBirth = c.DateTime(nullable: false),
                        NIF = c.String(nullable: false, maxLength: 9),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 9),
                        Email = c.String(nullable: false, maxLength: 100),
                        Comments = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(nullable: false, maxLength: 9),
                        City = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.PersonalTrainer",
                c => new
                    {
                        PersonalTrainerID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CodePT = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false, maxLength: 100),
                        NIF = c.String(nullable: false, maxLength: 9),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 9),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PersonalTrainerID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: false)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Hour = c.Time(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        Comments = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainerID, cascadeDelete: false)
                .Index(t => t.ClientID)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        UserCode = c.String(nullable: false, maxLength: 6),
                        Password = c.String(nullable: false, maxLength: 12),
                        Profile = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "PersonalTrainerID", "dbo.PersonalTrainer");
            DropForeignKey("dbo.Request", "ClientID", "dbo.Client");
            DropForeignKey("dbo.PersonalTrainer", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Client", "LocationID", "dbo.Location");
            DropIndex("dbo.Request", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Request", new[] { "ClientID" });
            DropIndex("dbo.PersonalTrainer", new[] { "LocationID" });
            DropIndex("dbo.Client", new[] { "LocationID" });
            DropTable("dbo.User");
            DropTable("dbo.Request");
            DropTable("dbo.PersonalTrainer");
            DropTable("dbo.Location");
            DropTable("dbo.Client");
        }
    }
}
