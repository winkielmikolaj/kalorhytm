using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.USDAFood.Models
{
    public class USDAFoodSearchResponse
    {
        [JsonPropertyName("totalHits")]
        public int TotalHits { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("foods")]
        public List<USDAFood> Foods { get; set; } = new();
    }

    public class USDAFood
    {
        [JsonPropertyName("fdcId")]
        public int FdcId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("dataType")]
        public string DataType { get; set; } = "";

        [JsonPropertyName("publicationDate")]
        public string PublicationDate { get; set; } = "";

        [JsonPropertyName("foodNutrients")]
        public List<USDAFoodNutrient> FoodNutrients { get; set; } = new();
    }

    public class USDAFoodNutrient
    {
        [JsonPropertyName("nutrientId")]
        public int NutrientId { get; set; }

        [JsonPropertyName("nutrientName")]
        public string NutrientName { get; set; } = "";

        [JsonPropertyName("nutrientNumber")]
        public string NutrientNumber { get; set; } = "";

        [JsonPropertyName("unitName")]
        public string UnitName { get; set; } = "";

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
} 