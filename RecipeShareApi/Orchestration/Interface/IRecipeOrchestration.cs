using RecipeShareApi.Models;

namespace RecipeShareApi.Orchestration.Interface
{
    public interface IRecipeOrchestration
    {
        Task<Recipe?> GetRecipeById(int id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(string? dietaryTag);
        Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe);
        Task<bool> DeleteRecipeAsync(int id);
    }
}
