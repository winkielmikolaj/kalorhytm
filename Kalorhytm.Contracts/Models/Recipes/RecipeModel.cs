namespace Kalorhytm.Contracts.Models.Recipes
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Likes { get; set; }

        public List<string> UsedIngredients { get; set; } = new();
        public List<string> MissedIngredients { get; set; } = new();
    }
}