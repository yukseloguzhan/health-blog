namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Message = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        FullName = c.String(),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contents", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ContentId", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "ContentId" });
            DropTable("dbo.Comments");
        }
    }
}
