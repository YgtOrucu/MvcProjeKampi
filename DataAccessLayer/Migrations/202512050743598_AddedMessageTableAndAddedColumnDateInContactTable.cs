namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMessageTableAndAddedColumnDateInContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50, unicode: false),
                        ReceiverMail = c.String(maxLength: 50, unicode: false),
                        MessageSubject = c.String(maxLength: 100, unicode: false),
                        MessageContent = c.String(maxLength: 100, unicode: false),
                        MessageDate = c.DateTime(nullable: false, storeType: "date",defaultValue:DateTime.Now),
                    })
                .PrimaryKey(t => t.MessageID);
            
            AddColumn("dbo.Contact", "ContactDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "ContactDate");
            DropTable("dbo.Message");
        }
    }
}
