namespace HealthBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(maxLength: 50),
                    CategoryDescription = c.String(),
                    CategoryStatus = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.CategoryId);

            //CreateTable(
            //    "dbo.Headings",
            //    c => new
            //    {
            //        HeadingId = c.Int(nullable: false, identity: true),
            //        HeadingName = c.String(),
            //        HeadingDate = c.DateTime(nullable: false),
            //        HeadingStatus = c.Boolean(nullable: false),
            //        CategoryId = c.Int(nullable: false),
            //        WriterId = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => t.HeadingId)
            //    .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
            //    .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
            //    .Index(t => t.CategoryId)
            //    .Index(t => t.WriterId);

            CreateTable(
                "dbo.Contents",
                c => new
                {
                    ContentId = c.Int(nullable: false, identity: true),
                    ContentValue = c.String(),
                    ContentDate = c.DateTime(nullable: false),
                    ContentStatus = c.Boolean(nullable: false),
                    CategoryId = c.Int(nullable: false),                  
                    WriterId = c.Int(),
                })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId)
                .Index(t => t.WriterId);

            CreateTable(
                "dbo.ImageFiles",
                c => new
                {
                    ImageId = c.Int(nullable: false, identity: true),
                    ImageName = c.String(),
                    ImagePath = c.String(),
                    ContentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Contents", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);

            CreateTable(
                "dbo.Writers",
                c => new
                {
                    WriterId = c.Int(nullable: false, identity: true),
                    WriterName = c.String(),
                    WriterSurname = c.String(),
                    WriterImage = c.String(),
                    WriterAbout = c.String(),
                    WriterMail = c.String(maxLength: 200),
                    WriterPassword = c.String(maxLength: 200),
                    WriterTitle = c.String(maxLength: 50),
                    WriterStatus = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.WriterId);

        //    CreateTable(
        //        "dbo.Wrongs",
        //        c => new
        //        {
        //            WrongId = c.Int(nullable: false, identity: true),
        //            Description = c.String(),
        //            CreatedDate = c.DateTime(nullable: false),
        //            Status = c.Boolean(nullable: false),
        //            WriterId = c.Int(nullable: false),
        //            CategoryId = c.Int(nullable: false),
        //        })
        //        .PrimaryKey(t => t.WrongId)
        //        .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
        //        .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
        //        .Index(t => t.WriterId)
        //        .Index(t => t.CategoryId);

        }

        public override void Down()
        {
           // DropForeignKey("dbo.Wrongs", "WriterId", "dbo.Writers");
            //DropForeignKey("dbo.Wrongs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.ImageFiles", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            //DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
           // DropIndex("dbo.Wrongs", new[] { "CategoryId" });
            //DropIndex("dbo.Wrongs", new[] { "WriterId" });
            DropIndex("dbo.ImageFiles", new[] { "ContentId" });
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
           // DropTable("dbo.Wrongs");
            DropTable("dbo.Writers");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Contents");
            DropTable("dbo.Headings");
            DropTable("dbo.Categories");
        }
    }

}
