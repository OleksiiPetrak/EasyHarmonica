namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyAchievement : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Achievements", "Date");
            DropColumn("dbo.Achievements", "PromotionPercentage");
            DropColumn("dbo.Achievements", "Timeliness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achievements", "Timeliness", c => c.Boolean(nullable: false));
            AddColumn("dbo.Achievements", "PromotionPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Achievements", "Date", c => c.DateTime(nullable: false));
        }
    }
}
