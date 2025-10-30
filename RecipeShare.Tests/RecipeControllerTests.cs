using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Tests
{
    public class RecipeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public RecipeControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllRecipes_ReturnsSuccessStatusCode()
        {
            // Arrange
            var request = "/api/recipe";
            // Act
            var response = await _client.GetAsync(request);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllRecipes_ReturnsJsonContent()
        {
            var response = await _client.GetAsync("/api/recipe");
            var contentType = response.Content.Headers.ContentType.MediaType;

            Assert.Equal("application/json", contentType);
        }
    }
}
