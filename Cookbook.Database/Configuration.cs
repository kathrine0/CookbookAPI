using Cookbook.Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Database
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 60 * 10;
        }

        protected override void Seed(DBContext context)
        {
            AddIngredients(context);
            AddCategories(context);
            AddRecipies(context);
        }


        private void AddIngredients(DBContext context)
        {
            var ingredients = new Ingredient[] 
            {
                new Ingredient() { Name = "jajko"},
                new Ingredient() { Name = "mleko"},
                new Ingredient() { Name = "mąka"},
                new Ingredient() { Name = "sól"},
                new Ingredient() { Name = "makaron"},
                new Ingredient() { Name = "mięso mielone"},
                new Ingredient() { Name = "pieprz"},
                new Ingredient() { Name = "curry"},
                new Ingredient() { Name = "cukier"},
                new Ingredient() { Name = "imbir"},
                new Ingredient() { Name = "wanilia"},
                new Ingredient() { Name = "czekolada"}
            };

            context.Ingredients.AddOrUpdate(x => x.Name, ingredients);
        }

        private void AddCategories(DBContext context)
        {
            var categories = new Category[] 
            {
                new Category() {Name = "Ciasta i desery"},
                new Category() {Name = "Potrawy z jaj"},
                new Category() {Name = "Potrawy z ryb"},
                new Category() {Name = "Potrawy z makaronem"},
                new Category() {Name = "Dania mięsne"},
                new Category() {Name = "Dania wegetariańskie"},
                new Category() {Name = "Zupy"}
            };

            context.Categories.AddOrUpdate(x => x.Name, categories);
        }

        private void AddRecipies(DBContext context)
        {
            var recipies = new Recipe[] {

            };
        }
    }

}
