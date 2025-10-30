using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeShareApi.Data;
using RecipeShareApi.Models;
using RecipeShareApi.Services.Interface;
using System;

namespace RecipeShareApi.Services.Implementation
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeDbContext _recipeDbContext;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(RecipeDbContext recipeDbContext, ILogger<RecipeService> logger)
        {
            _recipeDbContext = recipeDbContext;
            _logger = logger;
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _recipeDbContext.Recipes.Add(recipe);
            await _recipeDbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            _logger.LogInformation($"Deleting recipe with ID: {id}");
            var recipe = await _recipeDbContext.Recipes.FindAsync(id);
            if (recipe == null)
            {
                _logger.LogWarning($"Recipe with ID: {id} does not exist");
                return false;
            }

            _recipeDbContext.Recipes.Remove(recipe);
            await _recipeDbContext.SaveChangesAsync();
            _logger.LogInformation($"Recipe wth ID: {id} deleted successfully.");
            return true;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _recipeDbContext.Recipes.ToListAsync();

        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesByTagAsync(string? dietaryTag = null)
        {
            IQueryable<Recipe> query = _recipeDbContext.Recipes;

            if (!string.IsNullOrEmpty(dietaryTag))
            {
                query = query.Where(r => r.DietaryTag.ToLower() == dietaryTag.ToLower());
            }

            _logger.LogInformation("No dietary tag provided, fetching all recipes.");

            var recipes = await query.ToListAsync();

            if (recipes == null || !recipes.Any())
            {
                _logger.LogError($"No recipes found for the given dietary tag: {dietaryTag}");
                throw new KeyNotFoundException($"No recipes found for the dietary tag: {dietaryTag}");
            }

            return recipes;
        }

        public async Task<Recipe?> GetRecipeById(int id)
        {
            _logger.LogInformation($"Fetching recipe with ID: {id}");
            return await _recipeDbContext.Recipes.FindAsync(id);
        }

        public async Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe)
        {
            //var existing = await _recipeDbContext.Recipes.FindAsync(id);
            //if (existing == null) return null;

            //// Update only provided (non-null or valid) fields
            //if (!string.IsNullOrWhiteSpace(recipe.Title))
            //    existing.Title = recipe.Title;

            //if (!string.IsNullOrWhiteSpace(recipe.Steps))
            //    existing.Steps = recipe.Steps;

            //if (recipe.CookingTime > 0)
            //    existing.CookingTime = recipe.CookingTime;

            //if (recipe.Ingredients != null && recipe.Ingredients.Any())
            //    existing.Ingredients = recipe.Ingredients;

            //if (recipe.DietaryTag != null && recipe.DietaryTag.Any())
            //    existing.DietaryTag = recipe.DietaryTag;

            //await _recipeDbContext.SaveChangesAsync();
            //return existing;
            var recipeExist = await _recipeDbContext.Recipes.FindAsync(id);
            if (recipeExist == null)
            {
                _logger.LogWarning($"Recipe with ID: {id} not found.");
            }

            recipeExist.Title = recipe.Title;
            recipeExist.Ingredients = recipe.Ingredients;
            recipeExist.Steps = recipe.Steps;
            recipeExist.CookingTime = recipe.CookingTime;
            recipeExist.DietaryTag = recipe.DietaryTag;

            await _recipeDbContext.SaveChangesAsync();
            _logger.LogInformation($"Recipe with ID {id} successfully updated.");
            return recipeExist;
        }
    }
}
