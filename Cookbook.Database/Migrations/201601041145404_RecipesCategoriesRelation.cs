namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipesCategoriesRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Categories", new[] { "Recipe_Id" });
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Category_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Categories", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Recipe_Id", c => c.Int());
            DropForeignKey("dbo.RecipeCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.RecipeCategories", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeCategories", new[] { "Category_Id" });
            DropIndex("dbo.RecipeCategories", new[] { "Recipe_Id" });
            DropTable("dbo.RecipeCategories");
            CreateIndex("dbo.Categories", "Recipe_Id");
            AddForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
