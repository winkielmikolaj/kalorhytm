using System.Runtime.Serialization;

namespace Kalorhytm.Domain.Enums
{
    public enum SpoonacularDiet
    {
        [EnumMember(Value = "gluten free")]
        GlutenFree,

        [EnumMember(Value = "ketogenic")]
        Ketogenic,

        [EnumMember(Value = "vegetarian")]
        Vegetarian,

        [EnumMember(Value = "lacto-vegetarian")]
        LactoVegetarian,

        [EnumMember(Value = "ovo-vegetarian")]
        OvoVegetarian,

        [EnumMember(Value = "vegan")]
        Vegan,

        [EnumMember(Value = "pescetarian")]
        Pescetarian,

        [EnumMember(Value = "paleo")]
        Paleo,

        [EnumMember(Value = "primal")]
        Primal,

        [EnumMember(Value = "low fodmap")]
        LowFodmap,

        [EnumMember(Value = "whole30")]
        Whole30
    }
}