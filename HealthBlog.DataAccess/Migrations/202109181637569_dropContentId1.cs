namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropContentId1 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.ImageFiles", "Content_ContentId1");
        }

        public override void Down()
        {
        }
    }
}
