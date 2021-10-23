namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagefile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId");
            AlterColumn("dbo.ImageFiles", "Content_ContentId", c => c.Int());
            CreateIndex("dbo.ImageFiles", "Content_ContentId");
            AddForeignKey("dbo.ImageFiles", "Content_ContentId", "dbo.Contents", "ContentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageFiles", "Content_ContentId", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "Content_ContentId" });
            AlterColumn("dbo.ImageFiles", "Content_ContentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ImageFiles", name: "Content_ContentId", newName: "ContentId");
            CreateIndex("dbo.ImageFiles", "ContentId");
            AddForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents", "ContentId", cascadeDelete: true);
        }
    }
}
