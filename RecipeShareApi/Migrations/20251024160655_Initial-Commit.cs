using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeShareApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    DietaryTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "DietaryTag", "Ingredients", "Steps", "Title" },
                values: new object[,]
                {
                    { 1, 30, "Non-Vegetarian", "[\"200g spaghetti\",\"100g minced beef\",\"1 onion, chopped\",\"2 cloves garlic, minced\",\"400g canned tomatoes\",\"2 tbsp olive oil\",\"Salt and pepper to taste\"]", "[\"Cook spaghetti according to package instructions.\",\"Heat olive oil in a pan and saut\\u00E9 onion and garlic until translucent.\",\"Add minced beef and cook until browned.\",\"Stir in canned tomatoes and simmer for 15 minutes.\",\"Season with salt and pepper.\",\"Serve sauce over cooked spaghetti.\"]", "Spaghetti Bolognese" },
                    { 2, 20, "Vegan", "[\"1 cup broccoli florets\",\"1 cup sliced bell peppers\",\"1 cup snap peas\",\"2 carrots, sliced\",\"2 tbsp soy sauce\",\"1 tbsp sesame oil\",\"2 cloves garlic, minced\",\"1 tsp grated ginger\"]", "[\"Heat sesame oil in a large pan or wok.\",\"Add garlic and ginger, saut\\u00E9 for 1 minute.\",\"Add all vegetables and stir fry for 5-7 minutes until tender-crisp.\",\"Stir in soy sauce and cook for another 2 minutes.\",\"Serve hot with rice or noodles.\"]", "Vegetable Stir Fry" },
                    { 3, 15, "Non-Vegetarian", "[\"2 chicken breasts, grilled and sliced\",\"1 head romaine lettuce, chopped\",\"1/2 cup croutons\",\"1/4 cup grated Parmesan cheese\",\"Caesar dressing\"]", "[\"In a large bowl, combine chopped romaine lettuce, croutons, and Parmesan cheese.\",\"Top with sliced grilled chicken.\",\"Drizzle with Caesar dressing and toss to combine.\",\"Serve immediately.\"]", "Chicken Caesar Salad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
