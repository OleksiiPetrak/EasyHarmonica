namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "ImageData", c => c.Binary());
            AddColumn("dbo.Lessons", "ImageMimeType", c => c.String());
            AddColumn("dbo.Chapters", "ImageData", c => c.Binary());
            AddColumn("dbo.Chapters", "ImageMimeType", c => c.String());
            AddColumn("dbo.ClientProfiles", "ImageData", c => c.Binary());
            AddColumn("dbo.ClientProfiles", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientProfiles", "ImageMimeType");
            DropColumn("dbo.ClientProfiles", "ImageData");
            DropColumn("dbo.Chapters", "ImageMimeType");
            DropColumn("dbo.Chapters", "ImageData");
            DropColumn("dbo.Lessons", "ImageMimeType");
            DropColumn("dbo.Lessons", "ImageData");
        }
    }
}
