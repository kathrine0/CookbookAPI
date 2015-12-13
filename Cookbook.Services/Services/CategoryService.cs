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
    public class CategoryService
    {
        private DBContext db = new DBContext();

        public IList<CategoryDTO> GetCategories()
        {
            return Mapper.Map<IList<CategoryDTO>>(db.Categories.ToList());
        }

        public CategoryDTO GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new ItemNotFoundException();
            }

            return Mapper.Map<CategoryDTO>(category);
        }

        public void PutCategory(int id, CategoryDTO categoryDto)
        {
            var category = Mapper.Map<Category>(categoryDto);

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    throw new ItemNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public void PostCategory(CategoryDTO category)
        {
            db.Categories.Add(Mapper.Map<Category>(category));
            db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            
            if (category == null)
            {
                throw new ItemNotFoundException();
            }

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}
