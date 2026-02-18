using BookCart.Data.Entities;
using BookCart.Services.Models;

namespace BookCart.Services.Extensions;

public static class CategoryExtensions
{
    public static CategoryModel ToModel(this Category entity) => new() { Name = entity.Name, DisplayOrder = entity.DisplayOrder };

    public static IReadOnlyList<CategoryModel> ToModels(
        this IEnumerable<Category> entities) => [.. entities.Select(x => x.ToModel())];
}
