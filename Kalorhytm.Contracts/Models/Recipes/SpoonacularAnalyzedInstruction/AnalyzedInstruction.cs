namespace Kalorhytm.Contracts.Models.Recipes.SpoonacularAnalyzedInstruction
{
    public class AnalyzedInstruction
    {
        public string Name { get; set; }
        
        public List<InstructionStep> Steps { get; set; } = new();
    }
    
    public class InstructionStep
    {
        public int Number { get; set; }
        
        public string Step { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();
        
        public List<StepEquipment> Equipment { get; set; } = new();
        
        public StepLengthInfo? Length { get; set; }
    }
    
    public class StepEquipment
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Image { get; set; }
        
        public TemperatureInfo? Temperature { get; set; }
    }
    
    public class TemperatureInfo
    {
        public double Number { get; set; }
        
        public string Unit { get; set; }
    }
    
    public class StepLengthInfo
    {
        public double Number { get; set; }
        
        public string Unit { get; set; }
    }
    
    public class Ingredient
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = "";
        
        public double Amount { get; set; }
        
        public string Unit { get; set; } = "";
        
        public string Original { get; set; } = "";

        public string Image { get; set; } = "";
    }
}