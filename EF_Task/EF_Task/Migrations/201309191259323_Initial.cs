namespace EF_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Good = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goods", t => t.Good, cascadeDelete: true)
                .Index(t => t.Good);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Amount = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Structure",
                c => new
                    {
                        Category = c.Int(nullable: false),
                        Good = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category, t.Good })
                .ForeignKey("dbo.Categories", t => t.Category, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.Good, cascadeDelete: true)
                .Index(t => t.Category)
                .Index(t => t.Good);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Structure", new[] { "Good" });
            DropIndex("dbo.Structure", new[] { "Category" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.Payments", new[] { "Good" });
            DropForeignKey("dbo.Structure", "Good", "dbo.Goods");
            DropForeignKey("dbo.Structure", "Category", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Payments", "Good", "dbo.Goods");
            DropTable("dbo.Structure");
            DropTable("dbo.Categories");
            DropTable("dbo.Goods");
            DropTable("dbo.Payments");
        }
    }
}
