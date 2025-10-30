using Microsoft.AspNetCore.Mvc;
using RecipeShareApi.Models;
using RecipeShareApi.Orchestration.Interface;
using RecipeShareApi.Services.Interface;

namespace RecipeShareApi.Orchestration.Implementation
{
    public class RecipeOrchestration:IRecipeOrchestration
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeOrchestration> _logger;
        public RecipeOrchestration(IRecipeService recipeService, ILogger<RecipeOrchestration> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            try
            {
                _logger.LogInformation($"Adding reicpe: {recipe}");
                return await _recipeService.AddRecipeAsync(recipe);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error creating recipe {recipe.Title}");
                throw;
            }
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting recipe ID: {id}");
                return await _recipeService.DeleteRecipeAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting recipe with ID: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesByTagAsync([FromQuery] string? dietaryTag)
        {
            try
            {
                var recipes = await _recipeService.GetAllRecipesByTagAsync(dietaryTag);

                if (recipes == null || !recipes.Any())
                {
                    throw new KeyNotFoundException($"No recipes found for the dietary tag: {dietaryTag}");
                }

                return recipes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching recipes by dietary tag: {dietaryTag}");
                throw;
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            try
            {
                var recipes = await _recipeService.GetAllRecipesAsync();
                return recipes ?? Enumerable.Empty<Recipe>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured fetching all recipes");
                throw;
            }
        }

        public async Task<Recipe?> GetRecipeById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching recipe by ID: {id}");
                return await _recipeService.GetRecipeById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured fetching recipe ID: {id}");
                throw;
            }
        }

        public async Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe)
        {
            try
            {
                _logger.LogInformation($"Updating recipe ID: {id}");
                return await _recipeService.UpdateRecipeAsync(id, recipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating recipe ID: {id}");
                throw;
            }
        }
    }
}
