namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteheadingtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
         //   DropForeignKey("dbo.Contents", "Heading_HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
          //  DropIndex("dbo.Contents", new[] { "Heading_HeadingId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
         //   DropColumn("dbo.Contents", "Heading_HeadingId");
          //  DropTable("dbo.Headings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId);
            
            AddColumn("dbo.Contents", "Heading_HeadingId", c => c.Int());
            CreateIndex("dbo.Headings", "WriterId");
            CreateIndex("dbo.Headings", "CategoryId");
            CreateIndex("dbo.Contents", "Heading_HeadingId");
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "Heading_HeadingId", "dbo.Headings", "HeadingId");
            AddForeignKey("dbo.Headings", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
