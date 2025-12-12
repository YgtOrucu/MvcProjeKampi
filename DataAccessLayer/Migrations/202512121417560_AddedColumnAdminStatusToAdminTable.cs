namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnAdminStatusToAdminTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "AdminStatus");
        }
    }
}
