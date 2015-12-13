using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Cookbook.Services.DTO;
using Cookbook.Common;
using Cookbook.Services.Services;

namespace Cookbook.Controllers
{
    public class IngredientsController : ApiController
    {
        private IngredientService _service = new IngredientService();

        // GET: api/Ingredients
        public IList<IngredientDTO> GetIngredients()
        {
            return _service.GetIngredients();
        }

        // GET: api/Ingredients/5
        [ResponseType(typeof(IngredientDTO))]
        public IHttpActionResult GetIngredient(int id)
        {
            try
            {
                var ingredient = _service.GetIngredient(id);
                return Ok(ingredient);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Ingredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredient(int id, IngredientDTO ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.PutIngredient(id, ingredient);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ingredients
        [ResponseType(typeof(IngredientDTO))]
        public IHttpActionResult PostIngredient(IngredientDTO ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.PostIngredient(ingredient);

            return CreatedAtRoute("DefaultApi", new { id = ingredient.Id }, ingredient);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteIngredient(int id)
        {
            try
            {
                _service.DeleteIngredient(id);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}