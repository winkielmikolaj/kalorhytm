using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.Spoonacular.Models
{
    public class SpoonacularIngredient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";

        [JsonPropertyName("original")]
        public string Original { get; set; } = "";

        [JsonPropertyName("image")]
        public string Image { get; set; } = "";
    }
}