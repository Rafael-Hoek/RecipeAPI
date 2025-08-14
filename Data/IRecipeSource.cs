using RecipeAPI.Model;

namespace RecipeAPI.Data
{
    public interface IRecipeSource
    {
        public Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken = default);
        public Task<Recipe?> GetRecipeAsync(int id, CancellationToken cancellationToken = default);
        public Task<Recipe> AddRecipeAsync(Recipe recipe, CancellationToken cancellationToken = default);
        public Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken = default);
        public Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken = default);
    }
}
