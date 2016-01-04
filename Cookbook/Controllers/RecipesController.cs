using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Cookbook.Services.DTO;
using Cookbook.Common;
using Cookbook.Services.Services;

namespace Cookbook.Controllers
{
    public class RecipesController : ApiController
    {
        private RecipeService _service = new RecipeService();

        // GET: api/Recipes
        public IList<RecipeDTO> GetRecipes()
        {
            return _service.GetRecipes();
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(RecipeDTO))]
        public IHttpActionResult GetRecipe(int id)
        {
            try
            {
                var recipe = _service.GetRecipe(id);
                return Ok(recipe);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipe(int id, RecipeDTO recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.PutRecipe(id, recipe);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(PostRecipeDTO))]
        public IHttpActionResult PostRecipe(PostRecipeDTO recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedRecipe = _service.PostRecipe(recipe);

            return CreatedAtRoute("DefaultApi", new { id = savedRecipe.Id }, savedRecipe);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRecipe(int id)
        {
            try
            {
                _service.DeleteRecipe(id);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        public IList<RecipeDTO> GetRecipesByCategory(int categoryId)
        {
            return _service.GetRecipesByCategory(categoryId);
        }
    }
}