namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiaCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(maxLength: 1000, unicode: false),
                        AboutDetails2 = c.String(maxLength: 1000, unicode: false),
                        AboutImage1 = c.String(maxLength: 100, unicode: false),
                        AboutImage2 = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50, unicode: false),
                        CategoryDescription = c.String(maxLength: 200, unicode: false),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Heading",
                c => new
                    {
                        HeadingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50, unicode: false),
                        HeadingDate = c.DateTime(nullable: false, storeType: "date"),
                        CategoryID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: false)
                .ForeignKey("dbo.Writer", t => t.WriterID, cascadeDelete: false)
                .Index(t => t.CategoryID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000, unicode: false),
                        ContentDate = c.DateTime(nullable: false, storeType: "date"),
                        HeadingID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Heading", t => t.HeadingID, cascadeDelete: false)
                .ForeignKey("dbo.Writer", t => t.WriterID, cascadeDelete: false)
                .Index(t => t.HeadingID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Writer",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(maxLength: 30, unicode: false),
                        WriterSurname = c.String(maxLength: 30, unicode: false),
                        WriterImage = c.String(maxLength: 100, unicode: false),
                        WriterMail = c.String(maxLength: 50, unicode: false),
                        WriterPassword = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.WriterID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50, unicode: false),
                        UserMail = c.String(maxLength: 50, unicode: false),
                        Subject = c.String(maxLength: 50, unicode: false),
                        Message = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heading", "WriterID", "dbo.Writer");
            DropForeignKey("dbo.Content", "WriterID", "dbo.Writer");
            DropForeignKey("dbo.Content", "HeadingID", "dbo.Heading");
            DropForeignKey("dbo.Heading", "CategoryID", "dbo.Category");
            DropIndex("dbo.Content", new[] { "WriterID" });
            DropIndex("dbo.Content", new[] { "HeadingID" });
            DropIndex("dbo.Heading", new[] { "WriterID" });
            DropIndex("dbo.Heading", new[] { "CategoryID" });
            DropTable("dbo.Contact");
            DropTable("dbo.Writer");
            DropTable("dbo.Content");
            DropTable("dbo.Heading");
            DropTable("dbo.Category");
            DropTable("dbo.About");
        }
    }
}
