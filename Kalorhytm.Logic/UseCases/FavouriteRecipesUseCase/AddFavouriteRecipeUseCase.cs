using Kalorhytm.Contracts.Models.FavouriteRecipes;
using Kalorhytm.Domain.Entities.FavouriteRecipes;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases;

namespace Kalorhytm.Logic.UseCases.FavouriteRecipesUseCase
{
    public class AddFavouriteRecipeUseCase : IAddFavouriteRecipeUseCase
    {
        private readonly IFavouriteRecipesRepository _repository;

        public AddFavouriteRecipeUseCase(IFavouriteRecipesRepository repository)
        {
            _repository = repository;
        }


        public async Task<FavouriteRecipesModel> ExecuteAsync(FavouriteRecipesModel model)
        {
            var exists = await _repository.ExistsAsync(model.UserId, model.RecipeId);
            if (exists)
                throw new Exception("Recipe already saved as favourite");


            var entity = new FavouriteRecipesEntity
            {
                UserId = model.UserId,
                RecipeId = model.RecipeId,
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Likes = model.Likes,
                UsedIngredientsJson = model.UsedIngredientsJson,
                MissedIngredientsJson = model.MissedIngredientsJson
            };
            
            var saved = await _repository.AddAsync(entity);

            return new FavouriteRecipesModel
            {
                Id = saved.Id,
                UserId = saved.UserId,
                RecipeId = saved.RecipeId,
                Title = saved.Title,
                ImageUrl = saved.ImageUrl,
            };
        }
    }
}