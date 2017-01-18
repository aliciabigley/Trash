namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class routeviewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RouteViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RouteViewModels");
        }
    }
}
