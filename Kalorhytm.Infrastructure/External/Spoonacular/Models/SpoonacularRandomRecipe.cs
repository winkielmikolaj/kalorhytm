using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularRandomRecipeResponse
    {
        [JsonPropertyName("recipes")]
        public List<SpoonacularRandomRecipe> Recipes { get; set; } = new();
    }
    
    
    public class SpoonacularRandomRecipe
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("image")]
        public string Image { get; set; } = "";

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; } = "";
    }
}