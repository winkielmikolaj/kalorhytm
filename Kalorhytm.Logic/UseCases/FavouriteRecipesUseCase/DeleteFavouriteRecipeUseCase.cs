using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases;

namespace Kalorhytm.Logic.UseCases.FavouriteRecipesUseCase
{
    public class DeleteFavouriteRecipeUseCase : IDeleteFavouriteRecipeUseCase
    {
        private readonly IFavouriteRecipesRepository _repository;

        public DeleteFavouriteRecipeUseCase(IFavouriteRecipesRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int recipeId, string userId)
        {
            bool deleted = await _repository.DeleteAsync(recipeId, userId);

            if (!deleted)
            {
                throw new InvalidOperationException("There is no favourite recipe with matching ID.");
            }
        }
    }
}