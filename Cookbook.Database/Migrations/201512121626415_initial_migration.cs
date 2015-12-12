namespace Cookbook.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Image = c.String(),
                        StepNo = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Steps", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Categories", new[] { "Recipe_Id" });
            DropTable("dbo.Steps");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Categories");
        }
    }
}
