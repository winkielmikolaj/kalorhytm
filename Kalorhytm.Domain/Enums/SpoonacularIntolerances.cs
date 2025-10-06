using System.Runtime.Serialization;

namespace Kalorhytm.Domain.Enums
{
    public enum SpoonacularIntolerances
    {
        [EnumMember(Value = "dairy")]
        Dairy,

        [EnumMember(Value = "egg")]
        Egg,

        [EnumMember(Value = "gluten")]
        Gluten,

        [EnumMember(Value = "grain")]
        Grain,

        [EnumMember(Value = "peanut")]
        Peanut,

        [EnumMember(Value = "seafood")]
        Seafood,

        [EnumMember(Value = "sesame")]
        Sesame,

        [EnumMember(Value = "shellfish")]
        Shellfish,

        [EnumMember(Value = "soy")]
        Soy,

        [EnumMember(Value = "sulfite")]
        Sulfite,

        [EnumMember(Value = "tree nut")]
        TreeNut,

        [EnumMember(Value = "wheat")]
        Wheat
    }
}