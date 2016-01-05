namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeStepsOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Steps", new[] { "Recipe_Id" });
            AlterColumn("dbo.Steps", "Recipe_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Steps", "Recipe_Id");
            AddForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Steps", new[] { "Recipe_Id" });
            AlterColumn("dbo.Steps", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Steps", "Recipe_Id");
            AddForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
