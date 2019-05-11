namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonRequireChapter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Lessons", new[] { "ChapterId" });
            AlterColumn("dbo.Lessons", "ChapterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "ChapterId");
            AddForeignKey("dbo.Lessons", "ChapterId", "dbo.Chapters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Lessons", new[] { "ChapterId" });
            AlterColumn("dbo.Lessons", "ChapterId", c => c.Int());
            CreateIndex("dbo.Lessons", "ChapterId");
            AddForeignKey("dbo.Lessons", "ChapterId", "dbo.Chapters", "Id");
        }
    }
}
