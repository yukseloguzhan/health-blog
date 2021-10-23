namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontenttitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentTitle");
        }
    }
}
