namespace Kalorhytm.Contracts.Models.Recipes
{
    // extended ingredient jest zawarty w get recipe information
    public class ExtendedIngredient
    {
        public string Aisle { get; set; } = "";
        public double Amount { get; set; }

        public string Consistency { get; set; } = "";

        public int Id { get; set; }

        public string Image { get; set; } = "";

        public Measures Measures { get; set; } = new();

        public List<string> Meta { get; set; } = new();

        public string Name { get; set; } = "";

        public string Original { get; set; } = "";
        
        public string OriginalName { get; set; } = "";
        
        public string Unit { get; set; } = "";
    }

    public class Measures
    {
        public MeasureUnit Metric { get; set; } = new();
        
        public MeasureUnit Us { get; set; } = new();
    }
    
    public class MeasureUnit
    {
        public double Amount { get; set; }
        
        public string UnitLong { get; set; } = "";
        
        public string UnitShort { get; set; } = "";
    }
}