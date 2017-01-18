namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RouteViewModels", "Customerid", c => c.Int(nullable: false));
            CreateIndex("dbo.RouteViewModels", "Customerid");
            AddForeignKey("dbo.RouteViewModels", "Customerid", "dbo.CustomerModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteViewModels", "Customerid", "dbo.CustomerModels");
            DropIndex("dbo.RouteViewModels", new[] { "Customerid" });
            DropColumn("dbo.RouteViewModels", "Customerid");
        }
    }
}
