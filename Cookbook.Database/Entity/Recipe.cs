using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Database.Entity
{
    public class Recipe
    {
        public Recipe()
        {
            Steps = new List<Step>();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Step> Steps { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Ingredient> Ingredients { get; set; }

    }
}