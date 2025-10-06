using System.Runtime.Serialization;

namespace Kalorhytm.Domain.Enums
{
    public enum SpoonacularMealType
    {
        [EnumMember(Value = "main course")]
        MainCourse,

        [EnumMember(Value = "side dish")]
        SideDish,

        [EnumMember(Value = "dessert")]
        Dessert,

        [EnumMember(Value = "appetizer")]
        Appetizer,

        [EnumMember(Value = "salad")]
        Salad,

        [EnumMember(Value = "bread")]
        Bread,

        [EnumMember(Value = "breakfast")]
        Breakfast,

        [EnumMember(Value = "soup")]
        Soup,

        [EnumMember(Value = "beverage")]
        Beverage,

        [EnumMember(Value = "sauce")]
        Sauce,

        [EnumMember(Value = "marinade")]
        Marinade,

        [EnumMember(Value = "fingerfood")]
        Fingerfood,

        [EnumMember(Value = "snack")]
        Snack,

        [EnumMember(Value = "drink")]
        Drink
    }
}