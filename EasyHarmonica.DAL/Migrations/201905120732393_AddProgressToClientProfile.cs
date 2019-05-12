namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgressToClientProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientProfiles", "Progress", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientProfiles", "Progress");
        }
    }
}
