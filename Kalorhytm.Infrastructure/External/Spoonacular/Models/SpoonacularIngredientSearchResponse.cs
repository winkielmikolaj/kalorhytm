using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularIngredientSearchResponse
    {
        [JsonPropertyName("results")]
        public List<SpoonacularIngredientSearchResult> Results { get; set; } = new();
        
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        
        [JsonPropertyName("number")]
        public int Number { get; set; }
        
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }
    }
    
    public class SpoonacularIngredientSearchResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        
        [JsonPropertyName("image")]
        public string Image { get; set; } = "";
    }
}

