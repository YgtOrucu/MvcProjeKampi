namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusForAllTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.About", "AboutStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Heading", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Content", "ContentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writer", "WriterStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contact", "ContactStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "ContactStatus");
            DropColumn("dbo.Writer", "WriterStatus");
            DropColumn("dbo.Content", "ContentStatus");
            DropColumn("dbo.Heading", "HeadingStatus");
            DropColumn("dbo.About", "AboutStatus");
        }
    }
}
