namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagecontent5 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            //DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            //RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId1");
            //AddColumn("dbo.ImageFiles", "Content_ContentId", c => c.Int(nullable: false));
            //AlterColumn("dbo.ImageFiles", "Content_ContentId1", c => c.Int());
            //CreateIndex("dbo.ImageFiles", "Content_ContentId1");
            //AddForeignKey("dbo.ImageFiles", "Content_ContentId1", "dbo.Contents", "ContentId");
        }

        public override void Down()
        {
        }
    }
}
