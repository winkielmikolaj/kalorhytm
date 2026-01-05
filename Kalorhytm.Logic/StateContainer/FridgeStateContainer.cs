using Kalorhytm.Contracts.Models.Recipes;

namespace Kalorhytm.Logic.StateContainer
{
    public class FridgeStateContainer
    {
        // Tutaj przechowujemy listę przepisów
        public List<RecipeModel>? StoredRecipes { get; set; }
        
        // Opcjonalnie: możemy zapamiętać też komunikat błędu wyszukiwania
        public string? SearchMessage { get; set; }
    }
}