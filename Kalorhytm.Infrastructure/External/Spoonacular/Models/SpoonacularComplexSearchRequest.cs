using Kalorhytm.Domain.Enums;
using Refit;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularComplexSearchRequest
    {
    [AliasAs("query")]
    public string Query { get; set; } = "";

    [AliasAs("cuisine")]
    public string Cuisine { get; set; } = "";

    [AliasAs("excludeCuisine")]
    public string ExcludeCuisine { get; set; } = "";

    [AliasAs("diet")]
    public string Diet { get; set; } = "";

    [AliasAs("intolerances")]
    public string Intolerances { get; set; } = "";

    [AliasAs("equipment")]
    public string Equipment { get; set; } = "";

    [AliasAs("includeIngredients")]
    public string IncludeIngredients { get; set; } = "";

    [AliasAs("excludeIngredients")]
    public string ExcludeIngredients { get; set; } = "";

    [AliasAs("type")]
    public string Type { get; set; } = "";

    [AliasAs("instructionsRequired")]
    public bool InstructionsRequired { get; set; } = true;

    [AliasAs("fillIngredients")]
    public bool FillIngredients { get; set; } = false;

    [AliasAs("addRecipeInformation")]
    public bool AddRecipeInformation { get; set; } = false;

    [AliasAs("addRecipeInstructions")]
    public bool AddRecipeInstructions { get; set; } = false;

    [AliasAs("addRecipeNutrition")]
    public bool AddRecipeNutrition { get; set; } = false;

    [AliasAs("author")]
    public string Author { get; set; } = "";

    [AliasAs("tags")]
    public string Tags { get; set; } = "";

    [AliasAs("titleMatch")]
    public string TitleMatch { get; set; } = "";

    [AliasAs("maxReadyTime")]
    public int? MaxReadyTime { get; set; }

    [AliasAs("minServings")]
    public int? MinServings { get; set; }

    [AliasAs("maxServings")]
    public int? MaxServings { get; set; }

    [AliasAs("ignorePantry")]
    public bool IgnorePantry { get; set; } = true;

    [AliasAs("sort")]
    public string Sort { get; set; } = "";

    [AliasAs("sortDirection")]
    public string SortDirection { get; set; } = "";
    
    [AliasAs("minCarbs")]
    public int? MinCarbs { get; set; }

    [AliasAs("maxCarbs")]
    public int? MaxCarbs { get; set; }

    [AliasAs("minProtein")]
    public int? MinProtein { get; set; }

    [AliasAs("maxProtein")]
    public int? MaxProtein { get; set; }

    [AliasAs("minFat")]
    public int? MinFat { get; set; }

    [AliasAs("maxFat")]
    public int? MaxFat { get; set; }

    [AliasAs("minCalories")]
    public int? MinCalories { get; set; }

    [AliasAs("maxCalories")]
    public int? MaxCalories { get; set; }
    
    // tutaj jeszcze w dokumentacji spoonacular jest min/maxAlcohol, min/maxCaffeine, Copper, Calcium, Choline, Cholesterol ... VitaminA,K itd
    // mozna zaimplementowac w razie potrzeby

    [AliasAs("offset")]
    public int Offset { get; set; } = 0;

    [AliasAs("number")]
    public int Number { get; set; } = 10;
    }
}