namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantityIsAFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeIngredients", "Quantity", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeIngredients", "Quantity", c => c.Int(nullable: false));
        }
    }
}
