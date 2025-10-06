using System.Runtime.Serialization;

namespace Kalorhytm.Domain.Enums
{
    public enum SpoonacularRecipeSortOption
    {
        [EnumMember(Value = "meta-score")]
        MetaScore,

        [EnumMember(Value = "popularity")]
        Popularity,

        [EnumMember(Value = "healthiness")]
        Healthiness,

        [EnumMember(Value = "price")]
        Price,

        [EnumMember(Value = "time")]
        Time,

        [EnumMember(Value = "random")]
        Random,

        [EnumMember(Value = "max-used-ingredients")]
        MaxUsedIngredients,

        [EnumMember(Value = "min-missing-ingredients")]
        MinMissingIngredients,

        [EnumMember(Value = "calories")]
        Calories,

        [EnumMember(Value = "carbs")]
        Carbs,

        [EnumMember(Value = "protein")]
        Protein,

        [EnumMember(Value = "total-fat")]
        TotalFat,

        [EnumMember(Value = "saturated-fat")]
        SaturatedFat,

        [EnumMember(Value = "mono-unsaturated-fat")]
        MonoUnsaturatedFat,

        [EnumMember(Value = "poly-unsaturated-fat")]
        PolyUnsaturatedFat,

        [EnumMember(Value = "fiber")]
        Fiber
    }
}