using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Database.Entity
{
    public class Recipe : IEntity
    {
        public Recipe()
        {
            Steps = new List<Step>();
            Categories = new List<Category>();
            Ingredients = new List<RecipeIngredient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IList<Step> Steps { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<RecipeIngredient> Ingredients { get; set; }

    }
}