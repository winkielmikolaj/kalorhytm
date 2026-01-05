namespace Kalorhytm.Logic.Interfaces.IRecipeLikes
{
    public interface IGetRecipeLikesUseCase
    {
        Task<Dictionary<int, int>> ExecuteAsync(List<int> recipeIds);
    }
}