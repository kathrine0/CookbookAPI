namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageForRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "ImageUrl");
        }
    }
}
