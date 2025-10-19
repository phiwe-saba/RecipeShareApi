namespace RecipeShareApi.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public List<string> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public string CookingTime { get; set; }
        public string DietaryTag { get; set; }
    }
}
