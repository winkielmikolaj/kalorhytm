using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularRecipe
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("image")]
        public string Image { get; set; } = "";

        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        [JsonPropertyName("usedIngredients")]
        public List<SpoonacularIngredient> UsedIngredients { get; set; } = new();

        [JsonPropertyName("missedIngredients")]
        public List<SpoonacularIngredient> MissedIngredients { get; set; } = new();

        [JsonPropertyName("unusedIngredients")]
        public List<SpoonacularIngredient> UnusedIngredients { get; set; } = new();

        [JsonPropertyName("usedIngredientCount")]
        public int UsedIngredientCount { get; set; }

        [JsonPropertyName("missedIngredientCount")]
        public int MissedIngredientCount { get; set; }
    }
}