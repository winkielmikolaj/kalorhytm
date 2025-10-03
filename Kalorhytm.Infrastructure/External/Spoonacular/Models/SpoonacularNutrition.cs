using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularNutrition
    {
        [JsonPropertyName("nutrients")]
        public List<SpoonacularNutrient> Nutrients { get; set; } = new();

        [JsonPropertyName("properties")]
        public List<SpoonacularProperty> Properties { get; set; } = new();

        [JsonPropertyName("flavonoids")]
        public List<SpoonacularFlavonoid> Flavonoids { get; set; } = new();

        [JsonPropertyName("ingredients")]
        public List<SpoonacularIngredientNutrition> Ingredients { get; set; } = new();

        [JsonPropertyName("caloricBreakdown")]
        public SpoonacularCaloricBreakdown CaloricBreakdown { get; set; } = new();

        [JsonPropertyName("weightPerServing")]
        public SpoonacularWeightPerServing WeightPerServing { get; set; } = new();
    }

    public class SpoonacularNutrient
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";

        [JsonPropertyName("percentOfDailyNeeds")]
        public double PercentOfDailyNeeds { get; set; }
    }

    public class SpoonacularProperty
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }

    public class SpoonacularFlavonoid
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }

    public class SpoonacularIngredientNutrition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";

        [JsonPropertyName("nutrients")]
        public List<SpoonacularNutrient> Nutrients { get; set; } = new();
    }

    public class SpoonacularCaloricBreakdown
    {
        [JsonPropertyName("percentProtein")]
        public double PercentProtein { get; set; }

        [JsonPropertyName("percentFat")]
        public double PercentFat { get; set; }

        [JsonPropertyName("percentCarbs")]
        public double PercentCarbs { get; set; }
    }

    public class SpoonacularWeightPerServing
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }
}