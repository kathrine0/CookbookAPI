using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Database.Entity
{
    public class RecipeIngredient : IEntity
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public int Quantity {get; set; }
        public string Unit { get; set; }
    }
}
