﻿using AutoMapper;
using Cookbook.Database;
using Cookbook.Database.Entity;
using Cookbook.Services.DTO;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Cookbook.Common;

namespace Cookbook.Services.Services
{
    public class RecipeService
    {
        private DBContext db = new DBContext();

        public IList<RecipeDTO> GetRecipes()
        {
            var recipes = db.Recipes
                .Include(x => x.Categories)
                .OrderBy(x => x.Title)
                .ToList();

            return Mapper.Map<IList<RecipeDTO>>(recipes);
        }

        public RecipeDTO GetRecipe(int id)
        {
            Recipe recipe = db.Recipes.Include(x => x.Categories).FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                throw new ItemNotFoundException();
            }

            return Mapper.Map<RecipeDTO>(recipe);
        }

        public void PutRecipe(int id, RecipeDTO recipeDto)
        {
            var recipe = Mapper.Map<Recipe>(recipeDto);

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    throw new ItemNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public RecipeDTO PostRecipe(PostRecipeDTO recipeDto)
        {
            var recipe = Mapper.Map<Recipe>(recipeDto);

            var categories = db.Categories.Where(x => recipeDto.Categories.Contains(x.Id)).ToList();
            recipe.Categories = categories;

            db.Recipes.Add(recipe);
            db.SaveChanges();

            db.Entry(recipe).GetDatabaseValues();

            return Mapper.Map<RecipeDTO>(recipe);
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            
            if (recipe == null)
            {
                throw new ItemNotFoundException();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.Id == id) > 0;
        }

        public IList<RecipeDTO> GetRecipesByCategory(int categoryId)
        {
            return Mapper.Map<IList<RecipeDTO>>(
                db.Recipes
                .Include(x => x.Categories)
                .Where(x => x.Categories.Any(y => y.Id == categoryId))
                .ToList());
        }

        public IList<RecipeDTO> GetRecipesBySearchString(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return Mapper.Map<IList<RecipeDTO>>(db.Recipes.Include(x => x.Categories).ToList());
            }

            query = query.Replace("%20", " ");
            
            IList<string> searchPhrases = query.Split(',').ToList();

            for (var i = 0; i<searchPhrases.Count; i++)
            {
                searchPhrases[i] = searchPhrases[i].RemoveDiacritics()
                                                   .RemoveSpecialCharacters()
                                                   .ToLower();
            }

            return Mapper.Map<IList<RecipeDTO>>(
                db.Recipes
                .Include(x => x.Categories)
                .Where(x => x.Ingredients.Any(y =>
                            searchPhrases.Any(z => y.Ingredient.Name.Contains(z))) ||
                            searchPhrases.Any(z => x.Title.Contains(z)))
                .ToList());
        }
    }
}
