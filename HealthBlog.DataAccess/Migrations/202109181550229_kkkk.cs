namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            //RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId1");
            //AddColumn("dbo.ImageFiles", "Content_ContentId", c => c.Int(nullable: false));
            //AlterColumn("dbo.ImageFiles", "Content_ContentId1", c => c.Int());
            //CreateIndex("dbo.ImageFiles", "Content_ContentId1");
            //AddForeignKey("dbo.ImageFiles", "Content_ContentId1", "dbo.Contents", "ContentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageFiles", "Content_ContentId1", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "Content_ContentId1" });
            AlterColumn("dbo.ImageFiles", "Content_ContentId1", c => c.Int(nullable: false));
            DropColumn("dbo.ImageFiles", "Content_ContentId");
            RenameColumn(table: "dbo.ImageFiles", name: "Content_ContentId1", newName: "ContentId");
            CreateIndex("dbo.ImageFiles", "ContentId");
            AddForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents", "ContentId", cascadeDelete: true);
        }
    }
}
