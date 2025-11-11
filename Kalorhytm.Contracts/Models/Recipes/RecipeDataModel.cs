namespace Kalorhytm.Contracts.Models.Recipes
{
    public class RecipeDataModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Servings { get; set; }
        public int? ReadyInMinutes { get; set; } 
        public List<string> DishTypes { get; set; } = new();
        public List<string> Cuisines { get; set; } = new();
        public string Summary { get; set; } = "";
        
        public List<string> Tags { get; set; } = new();
    }
}