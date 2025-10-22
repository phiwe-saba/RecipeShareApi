using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShareApi.Models;
using RecipeShareApi.Orchestration.Interface;

namespace RecipeShareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeOrchestration _recipeOrchestration;

        public RecipeController(IRecipeOrchestration recipeOrchestration)
        {
            _recipeOrchestration = recipeOrchestration;
        }

        [HttpGet("{string}")]
        public async Task<IActionResult> GetAllRecipesByTagAsync([FromQuery] string? dietaryTag)
        {
            var recipes = await _recipeOrchestration.GetAllRecipesByTagAsync(dietaryTag);
            return Ok(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            var recipes = await _recipeOrchestration.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeOrchestration.GetRecipeById(id);
            return recipe == null ? NotFound() : Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
        {
            var createRecipe = await _recipeOrchestration.AddRecipeAsync(recipe);
            return Ok(createRecipe);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            var updateRecipe = await _recipeOrchestration.UpdateRecipeAsync(id, recipe);
            return updateRecipe != null ? Ok(updateRecipe) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var deleteRecipe = await _recipeOrchestration.DeleteRecipeAsync(id);
            return deleteRecipe ? Ok(deleteRecipe) : NotFound();
        }
    }
}
