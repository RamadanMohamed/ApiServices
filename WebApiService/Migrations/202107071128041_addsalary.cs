namespace WebApiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
