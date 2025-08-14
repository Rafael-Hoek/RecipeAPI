using RecipeAPI.Model;

namespace RecipeAPI.Data
{
    public class InMemoryRecipeSource : IRecipeSource
    {
        public Task<Recipe> AddRecipeAsync(Recipe recipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe?> GetRecipeAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
