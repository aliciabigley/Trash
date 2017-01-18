namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsernamePassToIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerUsernamePasswords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customerid = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CustomerModels", t => t.Customerid, cascadeDelete: true)
                .Index(t => t.Customerid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerUsernamePasswords", "Customerid", "dbo.CustomerModels");
            DropIndex("dbo.CustomerUsernamePasswords", new[] { "Customerid" });
            DropTable("dbo.CustomerUsernamePasswords");
        }
    }
}
