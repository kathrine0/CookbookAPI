﻿using Cookbook.Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Database
{
    public class DBContext : DbContext
    {
        public DBContext()
            :base("CookbookConnectionString")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>()
                .HasMany<Step>(s => s.Steps)
                .WithRequired()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>()
                .HasMany<Category>(s => s.Categories)
                .WithMany(c => c.Recipes);
        }
    }
}
