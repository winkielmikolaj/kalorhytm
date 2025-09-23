using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.Spoonacular.Models
{
    public class SpoonacularRecipeData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("image")]
        public string Image { get; set; } = "";

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; } = "";

        [JsonPropertyName("servings")]
        public int Servings { get; set; }

        [JsonPropertyName("readyInMinutes")]
        public int ReadyInMinutes { get; set; }

        [JsonPropertyName("cookingMinutes")]
        public int CookingMinutes { get; set; }

        [JsonPropertyName("preparationMinutes")]
        public int PreparationMinutes { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; } = "";

        [JsonPropertyName("sourceName")]
        public string SourceName { get; set; } = "";

        [JsonPropertyName("sourceUrl")]
        public string SourceUrl { get; set; } = "";

        [JsonPropertyName("spoonacularSourceUrl")]
        public string SpoonacularSourceUrl { get; set; } = "";

        [JsonPropertyName("healthScore")]
        public double HealthScore { get; set; }

        [JsonPropertyName("spoonacularScore")]
        public double SpoonacularScore { get; set; }

        [JsonPropertyName("pricePerServing")]
        public double PricePerServing { get; set; }

        [JsonPropertyName("analyzedInstructions")]
        public List<object> AnalyzedInstructions { get; set; } = new();

        [JsonPropertyName("cheap")]
        public bool Cheap { get; set; }

        [JsonPropertyName("creditsText")]
        public string CreditsText { get; set; } = "";

        [JsonPropertyName("cuisines")]
        public List<string> Cuisines { get; set; } = new();

        [JsonPropertyName("dairyFree")]
        public bool DairyFree { get; set; }

        [JsonPropertyName("diets")]
        public List<string> Diets { get; set; } = new();

        [JsonPropertyName("gaps")]
        public string Gaps { get; set; } = "";

        [JsonPropertyName("glutenFree")]
        public bool GlutenFree { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; } = "";

        [JsonPropertyName("ketogenic")]
        public bool Ketogenic { get; set; }

        [JsonPropertyName("lowFodmap")]
        public bool LowFodmap { get; set; }

        [JsonPropertyName("occasions")]
        public List<string> Occasions { get; set; } = new();

        [JsonPropertyName("sustainable")]
        public bool Sustainable { get; set; }

        [JsonPropertyName("vegan")]
        public bool Vegan { get; set; }

        [JsonPropertyName("vegetarian")]
        public bool Vegetarian { get; set; }

        [JsonPropertyName("veryHealthy")]
        public bool VeryHealthy { get; set; }

        [JsonPropertyName("veryPopular")]
        public bool VeryPopular { get; set; }

        [JsonPropertyName("whole30")]
        public bool Whole30 { get; set; }

        [JsonPropertyName("weightWatcherSmartPoints")]
        public int WeightWatcherSmartPoints { get; set; }

        [JsonPropertyName("dishTypes")]
        public List<string> DishTypes { get; set; } = new();

        [JsonPropertyName("extendedIngredients")]
        public List<SpoonacularExtendedIngredient> ExtendedIngredients { get; set; } = new();

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = "";

        [JsonPropertyName("winePairing")]
        public SpoonacularWinePairing? WinePairing { get; set; }
    }

    public class SpoonacularExtendedIngredient
    {
        [JsonPropertyName("aisle")]
        public string Aisle { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("consistency")]
        public string Consistency { get; set; } = "";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; } = "";

        [JsonPropertyName("measures")]
        public SpoonacularMeasures Measures { get; set; } = new();

        [JsonPropertyName("meta")]
        public List<string> Meta { get; set; } = new();

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("original")]
        public string Original { get; set; } = "";

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; } = "";

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }

    public class SpoonacularMeasures
    {
        [JsonPropertyName("metric")]
        public SpoonacularMeasureUnit Metric { get; set; } = new();

        [JsonPropertyName("us")]
        public SpoonacularMeasureUnit Us { get; set; } = new();
    }

    public class SpoonacularMeasureUnit
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unitLong")]
        public string UnitLong { get; set; } = "";

        [JsonPropertyName("unitShort")]
        public string UnitShort { get; set; } = "";
    }

    public class SpoonacularWinePairing
    {
        [JsonPropertyName("pairedWines")]
        public List<string> PairedWines { get; set; } = new();

        [JsonPropertyName("pairingText")]
        public string PairingText { get; set; } = "";

        [JsonPropertyName("productMatches")]
        public List<SpoonacularProductMatch> ProductMatches { get; set; } = new();
    }

    public class SpoonacularProductMatch
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("price")]
        public string Price { get; set; } = "";

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = "";

        [JsonPropertyName("averageRating")]
        public double AverageRating { get; set; }

        [JsonPropertyName("ratingCount")]
        public double RatingCount { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; } = "";
    }
}
