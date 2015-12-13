using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Services.DTO
{
    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public IngredientDTO Ingredient { get; set; }
        public int Quantity {get; set; }
        public string Unit { get; set; }
    }
}
