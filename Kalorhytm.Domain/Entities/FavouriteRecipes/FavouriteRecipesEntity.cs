namespace Kalorhytm.Domain.Entities.FavouriteRecipes
{
    public class FavouriteRecipesEntity
    {
        public int Id { get; set; } // primary key
        public int RecipeId { get; set; } // id przepisu z api
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Likes { get; set; }
        
        public string UserId { get; set; } = "";

        
        public string UsedIngredientsJson { get; set; } = "";
        public string MissedIngredientsJson { get; set; } = "";
    }
}