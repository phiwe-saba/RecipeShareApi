using System.ComponentModel.DataAnnotations;

namespace RecipeShareApi.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [MinLength(1, ErrorMessage = "At least one ingredient is required")]
        public List<string> Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required")]
        public List<string> Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than zero")]
        public string CookingTime { get; set; }

        public string DietaryTag { get; set; }
    }
}
