namespace Kalorhytm.Contracts.Models.Recipes
{
        public class NutritionModel
        {
            public int RecipeId { get; set; }
            
            public List<NutrientModel> Nutrients { get; set; } = new();
            
            public List<NutritionPropertyModel> Properties { get; set; } = new();
            
            public List<FlavonoidModel> Flavonoids { get; set; } = new();
            
            public List<IngredientNutritionModel> Ingredients { get; set; } = new();
            
            public double PercentProtein { get; set; }
            public double PercentFat { get; set; }
            public double PercentCarbs { get; set; }
            
            public double WeightPerServing { get; set; }
            public string WeightUnit { get; set; } = "";
        }

        public class NutrientModel
        {
            public string Name { get; set; } = "";
            public double Amount { get; set; }
            public string Unit { get; set; } = "";
            public double PercentOfDailyNeeds { get; set; }
        }

        public class NutritionPropertyModel
        {
            public string Name { get; set; } = "";
            public double Amount { get; set; }
            public string Unit { get; set; } = "";
        }

        public class FlavonoidModel
        {
            public string Name { get; set; } = "";
            public double Amount { get; set; }
            public string Unit { get; set; } = "";
        }

        public class IngredientNutritionModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public double Amount { get; set; }
            public string Unit { get; set; } = "";

            public List<NutrientModel> Nutrients { get; set; } = new();
        }
}