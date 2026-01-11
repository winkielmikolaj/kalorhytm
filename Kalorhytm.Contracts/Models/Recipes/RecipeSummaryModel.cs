namespace Kalorhytm.Contracts.Models.Recipes
{
    public class RecipeSummaryModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string ImageType { get; set; } = "";
        public int Likes { get; set; } = 0;
    }
}