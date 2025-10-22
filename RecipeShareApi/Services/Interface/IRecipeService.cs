using RecipeShareApi.Models;

namespace RecipeShareApi.Services.Interface
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesByTagAsync(string? dietaryTag = null);
        Task<Recipe> GetRecipeById(int id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<bool> DeleteRecipeAsync(int id);
    }
}
