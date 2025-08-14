using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Data;
using RecipeAPI.Model;

namespace RecipeAPI.Control
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeSource _recipeSource;

        public RecipeController(IRecipeSource recipeSource)
        {
            _recipeSource = recipeSource;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes(CancellationToken cancellationToken)
        {
            try
            {
                var recipes = await _recipeSource.GetRecipesAsync(cancellationToken);
                return Ok(recipes);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(408, "Request timeout");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id, CancellationToken cancellationToken)
        {
            try
            {
                var recipe = await _recipeSource.GetRecipeAsync(id, cancellationToken);
                if (recipe == null)
                {
                    return NotFound();
                }
                return Ok(recipe);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(408, "Request timeout");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipe, CancellationToken cancellationToken)
        {
            try
            {
                var createdRecipe = await _recipeSource.AddRecipeAsync(recipe, cancellationToken);
                return CreatedAtAction(nameof(GetRecipe), new { id = createdRecipe.Id }, createdRecipe);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(408, "Request timeout");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, [FromBody] Recipe recipe, CancellationToken cancellationToken)
        {
            try
            {
                var updatedRecipe = await _recipeSource.UpdateRecipeAsync(id, recipe, cancellationToken);
                if (updatedRecipe == null)
                {
                    return NotFound();
                }
                return Ok(updatedRecipe);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(408, "Request timeout");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id, CancellationToken cancellationToken)
        {
            try
            {
                var deleted = await _recipeSource.DeleteRecipeAsync(id, cancellationToken);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (OperationCanceledException)
            {
                return StatusCode(408, "Request timeout");
            }
        }
    }
}
