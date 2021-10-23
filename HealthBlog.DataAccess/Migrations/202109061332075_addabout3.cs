namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addabout3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        AboutImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abouts");
        }
    }
}
