using Cookbook.Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Database
{
    class DBContext : DbContext
    {
        public DBContext()
            :base("CookbookConnectionString")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipies { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
