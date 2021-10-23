namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmessageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "NameAndSurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "NameAndSurname");
        }
    }
}
