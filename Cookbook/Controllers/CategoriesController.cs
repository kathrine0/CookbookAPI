using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Cookbook.Services.DTO;
using Cookbook.Common;
using Cookbook.Services.Services;

namespace Cookbook.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoryService _service = new CategoryService();

        // GET: api/Categories
        public IList<CategoryDTO> GetCategories()
        {
            return _service.GetCategories();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(CategoryDTO))]
        public IHttpActionResult GetCategory(int id)
        {
            try
            {
                var category = _service.GetCategory(id);
                return Ok(category);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.PutCategory(id, category);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(CategoryDTO))]
        public IHttpActionResult PostCategory(CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.PostCategory(category);

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                _service.DeleteCategory(id);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}