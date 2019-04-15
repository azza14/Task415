namespace DemoTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            AddColumn("dbo.Categories", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Product_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Categories", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Product_Id" });
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Categories", "Product_Id");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
