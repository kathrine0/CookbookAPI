using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Database.Entity
{
    public class Category : IEntity
    {
        public Category()
        {
            Recipes = new List<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Recipe> Recipes { get; set; }
    }
}