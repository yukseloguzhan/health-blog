namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagecontent4 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.ImageFiles", name: "Content_ContentId1", newName: "Content_ContentId");
            //RenameColumn(table: "dbo.ImageFiles", name: "ContentId", newName: "Content_ContentId");
            //DropColumn("dbo.ImageFiles", "Content_ContentId1");
        }
        
        public override void Down()
        {
        }
    }
}
