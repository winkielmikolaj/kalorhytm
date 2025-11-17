using Kalorhytm.Contracts.Models.Recipes.SpoonacularAnalyzedInstruction;

namespace Kalorhytm.Contracts.Models.Recipes
{
    public class RecipeDataModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Servings { get; set; }
        
        // te dwie rzeczy chyba sie zawrze w Tags
        public List<string> DishTypes { get; set; } = new();
        public List<string> Cuisines { get; set; } = new();
        public string Summary { get; set; } = "";
        
        public List<string> Tags { get; set; } = new();
        
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; } = new();
        
        public List<ExtendedIngredient> ExtendedIngredients { get; set; } = new();
    }
}