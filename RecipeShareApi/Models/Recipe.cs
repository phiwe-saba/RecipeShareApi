namespace RecipeShareApi.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public string CookingTime { get; set; }
        public string DietaryTag { get; set; }
    }
}
