using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IRecipeLikes;

namespace Kalorhytm.Logic.UseCases.RecipeLikes
{
    public class GetRecipeLikesUseCase : IGetRecipeLikesUseCase
    {
        private readonly IFavouriteRecipesRepository _repository;

        public GetRecipeLikesUseCase(IFavouriteRecipesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dictionary<int, int>> ExecuteAsync(List<int> recipeIds)
        {
            return await _repository.GetLikesCountForRecipesAsync(recipeIds);
        }
    }
}