namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagefile2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "ImageDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageFiles", "ImageDescription");
        }
    }
}
