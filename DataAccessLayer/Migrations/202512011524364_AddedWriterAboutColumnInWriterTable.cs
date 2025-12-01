namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWriterAboutColumnInWriterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writer", "WriterAbout", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Writer", "WriterPassword", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writer", "WriterPassword", c => c.String(maxLength: 20, unicode: false));
            DropColumn("dbo.Writer", "WriterAbout");
        }
    }
}
