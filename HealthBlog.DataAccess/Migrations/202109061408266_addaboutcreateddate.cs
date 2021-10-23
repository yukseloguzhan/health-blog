namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaboutcreateddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Abouts", "Activity", c => c.Boolean(nullable: false));
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "CreatedDate");
        }
    }
}
