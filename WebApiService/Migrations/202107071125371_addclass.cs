namespace WebApiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Deptid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Deptid, cascadeDelete: true)
                .Index(t => t.Deptid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Deptid", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Deptid" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
