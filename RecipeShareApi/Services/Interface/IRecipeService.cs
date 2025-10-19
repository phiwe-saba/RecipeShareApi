using RecipeShareApi.Models;

namespace RecipeShareApi.Services.Interface
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(string? dietaryTag = null);
        Task<Recipe> GetRecipeById(int id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe);
        Task<bool> DeleteRecipeAsync(int id);
    }
}
