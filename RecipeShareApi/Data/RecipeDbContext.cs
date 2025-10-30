using Microsoft.EntityFrameworkCore;
using RecipeShareApi.Models;

namespace RecipeShareApi.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 1,
                Title = "Spaghetti Bolognese",
                Ingredients = new List<string>
                {
                    "200g spaghetti",
                    "100g minced beef",
                    "1 onion, chopped",
                    "2 cloves garlic, minced",
                    "400g canned tomatoes",
                    "2 tbsp olive oil",
                    "Salt and pepper to taste"
                },
                Steps = new List<string>
                {
                    "Cook spaghetti according to package instructions.",
                    "Heat olive oil in a pan and sauté onion and garlic until translucent.",
                    "Add minced beef and cook until browned.",
                    "Stir in canned tomatoes and simmer for 15 minutes.",
                    "Season with salt and pepper.",
                    "Serve sauce over cooked spaghetti."
                },
                CookingTime = 30,
                DietaryTag = "Non-Vegetarian"
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 2,
                Title = "Vegetable Stir Fry",
                Ingredients = new List<string>
                {
                    "1 cup broccoli florets",
                    "1 cup sliced bell peppers",
                    "1 cup snap peas",
                    "2 carrots, sliced",
                    "2 tbsp soy sauce",
                    "1 tbsp sesame oil",
                    "2 cloves garlic, minced",
                    "1 tsp grated ginger"
                },
                Steps = new List<string>
                {
                    "Heat sesame oil in a large pan or wok.",
                    "Add garlic and ginger, sauté for 1 minute.",
                    "Add all vegetables and stir fry for 5-7 minutes until tender-crisp.",
                    "Stir in soy sauce and cook for another 2 minutes.",
                    "Serve hot with rice or noodles."
                },
                CookingTime = 20,
                DietaryTag = "Vegan"
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 3,
                Title = "Chicken Caesar Salad",
                Ingredients = new List<string>
                {
                    "2 chicken breasts, grilled and sliced",
                    "1 head romaine lettuce, chopped",
                    "1/2 cup croutons",
                    "1/4 cup grated Parmesan cheese",
                    "Caesar dressing"
                },
                Steps = new List<string>
                {
                    "In a large bowl, combine chopped romaine lettuce, croutons, and Parmesan cheese.",
                    "Top with sliced grilled chicken.",
                    "Drizzle with Caesar dressing and toss to combine.",
                    "Serve immediately."
                },
                CookingTime = 15,
                DietaryTag = "Non-Vegetarian"
            });

           
        }
        
    }
}
