namespace Northwind.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 12),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
