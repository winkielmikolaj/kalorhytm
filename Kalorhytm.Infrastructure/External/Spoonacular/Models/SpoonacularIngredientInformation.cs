using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularIngredientInformation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("original")]
        public string Original { get; set; } = "";
        
        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; } = "";
        
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
        
        [JsonPropertyName("unitShort")]
        public string UnitShort { get; set; } = "";
        
        [JsonPropertyName("unitLong")]
        public string UnitLong { get; set; } = "";
        
        [JsonPropertyName("possibleUnits")]
        public List<string> PossibleUnits { get; set; } = new();
        
        [JsonPropertyName("estimatedCost")]
        public SpoonacularEstimatedCost? EstimatedCost { get; set; }
        
        [JsonPropertyName("consistency")]
        public string Consistency { get; set; } = "";
        
        [JsonPropertyName("shoppingListUnits")]
        public List<string> ShoppingListUnits { get; set; } = new();
        
        [JsonPropertyName("aisle")]
        public string Aisle { get; set; } = "";
        
        [JsonPropertyName("image")]
        public string Image { get; set; } = "";
        
        [JsonPropertyName("meta")]
        public List<object> Meta { get; set; } = new();
        
        [JsonPropertyName("nutrition")]
        public SpoonacularIngredientNutritionInfo? Nutrition { get; set; }
        
        [JsonPropertyName("categoryPath")]
        public List<string> CategoryPath { get; set; } = new();
    }
    
    public class SpoonacularEstimatedCost
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }
    
    public class SpoonacularIngredientNutritionInfo
    {
        [JsonPropertyName("nutrients")]
        public List<SpoonacularIngredientNutrient> Nutrients { get; set; } = new();
        
        [JsonPropertyName("properties")]
        public List<SpoonacularIngredientProperty> Properties { get; set; } = new();
        
        [JsonPropertyName("flavonoids")]
        public List<SpoonacularIngredientFlavonoid> Flavonoids { get; set; } = new();
        
        [JsonPropertyName("caloricBreakdown")]
        public SpoonacularIngredientCaloricBreakdown? CaloricBreakdown { get; set; }
        
        [JsonPropertyName("weightPerServing")]
        public SpoonacularIngredientWeightPerServing? WeightPerServing { get; set; }
    }
    
    public class SpoonacularIngredientNutrient
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
        
        [JsonPropertyName("percentOfDailyNeeds")]
        public double? PercentOfDailyNeeds { get; set; }
    }
    
    public class SpoonacularIngredientProperty
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }
    
    public class SpoonacularIngredientFlavonoid
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }
    
    public class SpoonacularIngredientCaloricBreakdown
    {
        [JsonPropertyName("percentProtein")]
        public double PercentProtein { get; set; }
        
        [JsonPropertyName("percentFat")]
        public double PercentFat { get; set; }
        
        [JsonPropertyName("percentCarbs")]
        public double PercentCarbs { get; set; }
    }
    
    public class SpoonacularIngredientWeightPerServing
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "";
    }
}

