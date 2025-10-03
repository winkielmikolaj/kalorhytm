namespace Kalorhytm.Infrastructure.External.Spoonacular.Models
{
    public class SpoonacularComplexSearchResponse
    {
        public int Offset { get; set; }
        public int Number { get; set; }
        public int TotalResults { get; set; }
        public List<SpoonacularComplexSearchRecipe> Results { get; set; } = new();
    }

    public class SpoonacularComplexSearchRecipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string ImageType { get; set; } = string.Empty;
    }
}