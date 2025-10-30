using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeShareApi.Controllers;
using RecipeShareApi.Models;
using RecipeShareApi.Orchestration.Interface;
using Xunit;

namespace RecipeShareApi.Tests
{
    public class RecipeControllerTests
    {
        /*private readonly Mock<IRecipeOrchestration> _mockRecipeOrchestration;
        private readonly RecipeController _recipeController;

        public RecipeControllerTests()
        {
            _mockRecipeOrchestration = new Mock<IRecipeOrchestration>();
            var mockLogger = new Mock<ILogger<RecipeController>>();
            _recipeController = new RecipeController(_mockRecipeOrchestration.Object, mockLogger.Object);
        }

        [Fact]
        public async Task GetAllRecipesAsync_ShouldReturnOk_WithRecipeList()
        {
            // Arrange
            var recipes = new List<Recipe>
            {
                new Recipe { Id = 1, Title = "Spaghetti Bolognese" },
                new Recipe { Id = 2, Title = "Beef Tacos" }
            };
            _mockRecipeOrchestration.Setup(s => s.GetAllRecipesAsync())
                .ReturnsAsync(recipes);

            // Act
            var result = await _recipeController.GetAllRecipesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRecipes = Assert.IsAssignableFrom<IEnumerable<Recipe>>(okResult.Value);
            Assert.Equal(2, ((List<Recipe>)returnedRecipes).Count);
        }

        [Fact]
        public async Task GetAllRecipesAsync_ShouldReturnEmptyList_WhenNoRecipesExist()
        {
            _mockRecipeOrchestration.Setup(s => s.GetAllRecipesAsync())
                .ReturnsAsync(new List<Recipe>());

            var result = await _recipeController.GetAllRecipesAsync();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<Recipe>>(okResult.Value);
            Assert.Empty(recipes);
        }

        [Fact]
        public async Task GetRecipeById_ShouldReturnNotFound_WhenRecipeDoesNotExist()
        {
            _mockRecipeOrchestration.Setup(s => s.GetRecipeById(It.IsAny<int>()))
                .ReturnsAsync((Recipe?)null);

            var result = await _recipeController.GetByRecipeIdAsync(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateRecipe_ShouldReturnCreatedAtAction_WhenValid()
        {
            var recipe = new Recipe { Id = 3, Title = "New Recipe" };
            _mockRecipeOrchestration.Setup(s => s.AddRecipeAsync(recipe))
                .ReturnsAsync(recipe);

            var result = await _recipeController.CreateRecipe(recipe);

            var created = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetRecipeById", created.ActionName);
            Assert.Equal(recipe, created.Value);
        }

        [Fact]
        public async Task CreateRecipe_ShouldReturnBadRequest_WhenModelInvalid()
        {
            _recipeController.ModelState.AddModelError("Title", "Required");

            var result = await _recipeController.CreateRecipe(new Recipe());

            Assert.IsType<BadRequestObjectResult>(result);
        }
        */

    }
}
