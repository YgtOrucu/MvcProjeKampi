namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdminAndRoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleType = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admin", "RoleID", "dbo.Role");
            DropIndex("dbo.Admin", new[] { "RoleID" });
            DropTable("dbo.Role");
            DropTable("dbo.Admin");
        }
    }
}
