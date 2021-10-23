namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sil3 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ImageFiles", "Content_ContentId1", "dbo.Contents");
            //DropIndex("dbo.ImageFiles", new[] { "Content_ContentId1" });
            //RenameColumn(table: "dbo.ImageFiles", name: "Content_ContentId1", newName: "ContentId");
            //AlterColumn("dbo.ImageFiles", "ContentId", c => c.Int(nullable: false));
            //CreateIndex("dbo.ImageFiles", "ContentId");
            //AddForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents", "ContentId", cascadeDelete: true);
            //DropColumn("dbo.ImageFiles", "Content_ContentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageFiles", "Content_ContentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            AlterColumn("dbo.ImageFiles", "ContentId", c => c.Int());
            RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId1");
            CreateIndex("dbo.ImageFiles", "Content_ContentId1");
            AddForeignKey("dbo.ImageFiles", "Content_ContentId1", "dbo.Contents", "ContentId");
        }
    }
}
