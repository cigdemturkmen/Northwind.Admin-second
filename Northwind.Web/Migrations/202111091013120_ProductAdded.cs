namespace Northwind.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitInStock = c.Int(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        UpdatedById = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
        }
    }
}
