namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontent : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ImageFiles", "Content_ContentId", "dbo.Contents");
           // DropIndex("dbo.ImageFiles", new[] { "Content_ContentId" });
            //RenameColumn(table: "dbo.ImageFiles", name: "Content_ContentId", newName: "ContentId");
            //AlterColumn("dbo.ImageFiles", "ContentId", c => c.Int(nullable: false));
            //CreateIndex("dbo.ImageFiles", "ContentId");
            //AddForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents", "ContentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            AlterColumn("dbo.ImageFiles", "ContentId", c => c.Int());
            RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId");
            CreateIndex("dbo.ImageFiles", "Content_ContentId");
            AddForeignKey("dbo.ImageFiles", "Content_ContentId", "dbo.Contents", "ContentId");
        }
    }
}
