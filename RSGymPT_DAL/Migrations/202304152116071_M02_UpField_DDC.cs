namespace RSGymPT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M02_UpField_DDC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Client", "PersonalTrainerID", "dbo.PersonalTrainer");
            DropIndex("dbo.Client", new[] { "PersonalTrainerID" });
            DropColumn("dbo.Client", "PersonalTrainerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "PersonalTrainerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Client", "PersonalTrainerID");
            AddForeignKey("dbo.Client", "PersonalTrainerID", "dbo.PersonalTrainer", "PersonalTrainerID", cascadeDelete: true);
        }
    }
}
