using BookCart.Services.Models;

namespace BookCart.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<CategoryModel>> GetAll(CancellationToken ct);

    Task<CategoryModel?> GetById(int id, CancellationToken ct);

}
