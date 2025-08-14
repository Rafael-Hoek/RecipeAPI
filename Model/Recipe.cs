namespace RecipeAPI.Model
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Author Author { get; set; } = new Author();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        //Steps can be either iterated through recursively or as a flat list
        public List<Step> Steps { get; set; } = new List<Step>();
        public Step FirstStep { get; set; } = new Step();
    }
}
