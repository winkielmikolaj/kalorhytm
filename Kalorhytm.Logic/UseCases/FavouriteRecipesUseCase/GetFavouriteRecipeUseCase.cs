using Kalorhytm.Contracts.Models.FavouriteRecipes;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases;

namespace Kalorhytm.Logic.UseCases.FavouriteRecipesUseCase
{
    public class GetFavouriteRecipeUseCase : IGetFavouriteRecipeUseCase
    {
        private readonly IFavouriteRecipesRepository _repository;


        public GetFavouriteRecipeUseCase(IFavouriteRecipesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FavouriteRecipesModel>> ExecuteAsync(string userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);

            return entities.Select(e => new FavouriteRecipesModel
            {
                Id = e.Id,
                UserId = e.UserId,
                RecipeId = e.RecipeId,
                Title = e.Title,
                ImageUrl = e.ImageUrl,
                Likes = e.Likes,
                UsedIngredientsJson = e.UsedIngredientsJson,
                MissedIngredientsJson = e.MissedIngredientsJson
            }).ToList();
        }
    }
}