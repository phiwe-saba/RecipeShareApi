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
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeOrchestration recipeOrchestration, ILogger<RecipeController> logger)
        {
            _recipeOrchestration = recipeOrchestration;
            _logger = logger;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetAllRecipesByTagAsync([FromQuery] string? dietaryTag)
        {
            try
            {
                var recipes = await _recipeOrchestration.GetAllRecipesByTagAsync(dietaryTag);
                return Ok(recipes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching recipes by dietary tag: {dietaryTag}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            try
            {
                var recipes = await _recipeOrchestration.GetAllRecipesAsync();

                if (recipes == null || !recipes.Any())
                {
                    _logger.LogError("No recipes found in the database.");
                    return NotFound(new { Message = "No recipes found." });
                }
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all recipes.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByRecipeIdAsync(int id)
        {
            try
            {
                var recipe = await _recipeOrchestration.GetRecipeById(id);

                if (recipe == null)
                {
                    _logger.LogError($"Recipe with ID: {id} not found.");
                    return NotFound(new { Message = $"Recipe with ID: {id} not found." });
                }
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching recipe with ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
        {
            try
            {
                if (recipe == null)
                {
                    _logger.LogError("Recipe object sent from client is null.");
                    return BadRequest(new { Message = "Recipe object cannot be null." });
                }

                var createRecipe = await _recipeOrchestration.AddRecipeAsync(recipe);
                return Ok(createRecipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new recipe.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest(new { Message = "Invalid recipe supplied." });
                }

                var updateRecipe = await _recipeOrchestration.UpdateRecipeAsync(id, recipe);

                if (updateRecipe == null)
                {
                    _logger.LogError($"Recipe with ID: {id} not found for update.");
                    return NotFound(new { Message = $"Recipe with ID: {id} not found." });
                }
                return Ok(updateRecipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating recipe with ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            try
            {
                var deleteRecipe = await _recipeOrchestration.DeleteRecipeAsync(id);

                if (!deleteRecipe)
                {
                    _logger.LogError($"Recipe with ID: {id} not found for deletion.");
                    return NotFound(new { Message = $"Recipe with ID: {id} not found." });
                }
                return Ok(new { Message = $"Recipe with ID: {id} deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting recipe with ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
    }
}
