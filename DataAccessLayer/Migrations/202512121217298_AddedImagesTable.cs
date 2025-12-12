namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImagesID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        Path = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ImagesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
