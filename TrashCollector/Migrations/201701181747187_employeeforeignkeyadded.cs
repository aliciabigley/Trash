namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeforeignkeyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RouteViewModels", "Employeeid", c => c.Int(nullable: false));
            CreateIndex("dbo.RouteViewModels", "Employeeid");
            AddForeignKey("dbo.RouteViewModels", "Employeeid", "dbo.EmployeeModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteViewModels", "Employeeid", "dbo.EmployeeModels");
            DropIndex("dbo.RouteViewModels", new[] { "Employeeid" });
            DropColumn("dbo.RouteViewModels", "Employeeid");
        }
    }
}
