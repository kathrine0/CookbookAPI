using AutoMapper;
using Cookbook.Database;
using Cookbook.Database.Entity;
using Cookbook.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Cookbook.Common;

namespace Cookbook.Services.Services
{
    public class IngredientService
    {
        private DBContext db = new DBContext();

        public IList<IngredientDTO> GetIngredients()
        {
            return Mapper.Map<IList<IngredientDTO>>(db.Ingredients.ToList());
        }

        public IngredientDTO GetIngredient(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                throw new ItemNotFoundException();
            }

            return Mapper.Map<IngredientDTO>(ingredient);
        }

        public void PutIngredient(int id, IngredientDTO ingredientDto)
        {
            var ingredient = Mapper.Map<Ingredient>(ingredientDto);

            db.Entry(ingredient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    throw new ItemNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public void PostIngredient(IngredientDTO ingredient)
        {
            db.Ingredients.Add(Mapper.Map<Ingredient>(ingredient));
            db.SaveChanges();
        }

        public void DeleteIngredient(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            
            if (ingredient == null)
            {
                throw new ItemNotFoundException();
            }

            db.Ingredients.Remove(ingredient);
            db.SaveChanges();
        }

        private bool IngredientExists(int id)
        {
            return db.Ingredients.Count(e => e.Id == id) > 0;
        }
    }
}
