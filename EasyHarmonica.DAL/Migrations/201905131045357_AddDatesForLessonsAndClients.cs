namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesForLessonsAndClients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Duration", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ClientProfiles", "RegistrationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientProfiles", "RegistrationDate");
            DropColumn("dbo.Lessons", "Duration");
        }
    }
}
