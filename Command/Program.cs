using RecipeAPI.Data;
using RecipeAPI.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IRecipeSource, InMemoryRecipeSource>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

app.MapControllers();

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Recipe[]))]
[JsonSerializable(typeof(Recipe))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
