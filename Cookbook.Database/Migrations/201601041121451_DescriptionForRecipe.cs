namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionForRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Description");
        }
    }
}
