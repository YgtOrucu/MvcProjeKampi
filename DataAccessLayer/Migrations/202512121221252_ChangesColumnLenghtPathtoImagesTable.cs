namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesColumnLenghtPathtoImagesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImageFiles", "Path", c => c.String(maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "Path", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
