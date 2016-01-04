using AutoMapper;
using Cookbook.Database.Entity;
using Cookbook.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Services
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<CategoryDTO, Category>();

            Mapper.CreateMap<Category, int>()
                .ConstructUsing(source => source.Id);

            Mapper.CreateMap<Ingredient, int>()
                .ConstructUsing(source => source.Id);
            

            Mapper.CreateMap<Ingredient, IngredientDTO>();
            Mapper.CreateMap<IngredientDTO, Ingredient>();

            Mapper.CreateMap<Recipe, RecipeDTO>();
            Mapper.CreateMap<RecipeDTO, Recipe>();
            Mapper.CreateMap<PostRecipeDTO, Recipe>()
                .ForMember(dst => dst.Categories, opt => opt.Ignore());

            Mapper.CreateMap<RecipeIngredient, RecipeIngredientDTO>();
            Mapper.CreateMap<RecipeIngredientDTO, RecipeIngredient>();
            Mapper.CreateMap<PostRecipeIngredientDTO, RecipeIngredient>()
                .ForMember(dst => dst.IngredientId, opt => opt.MapFrom(dst => dst.IngredientId))
                .ForMember(dst => dst.Ingredient, opt => opt.Ignore());

            Mapper.CreateMap<Step, StepDTO>();
            Mapper.CreateMap<StepDTO, Step>();
        }
    }
}
