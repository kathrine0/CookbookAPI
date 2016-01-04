using Cookbook.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Services.DTO
{
    public class RecipeDTO : BaseRecipeDTO
    {
        public IList<CategoryDTO> Categories { get; set; }
        public IList<RecipeIngredientDTO> Ingredients { get; set; }
    }

    public class PostRecipeDTO : BaseRecipeDTO
    {
        public IList<int> Categories { get; set; }
        public IList<PostRecipeIngredientDTO> Ingredients { get; set; }
    }

    public abstract class BaseRecipeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IList<StepDTO> Steps { get; set; }
    }
}