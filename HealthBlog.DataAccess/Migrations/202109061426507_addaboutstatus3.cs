namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaboutstatus3 : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
