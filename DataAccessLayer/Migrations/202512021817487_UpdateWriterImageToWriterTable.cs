namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWriterImageToWriterTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writer", "WriterImage", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writer", "WriterImage", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
