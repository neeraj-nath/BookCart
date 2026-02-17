using BookCart.Data.Entities;

namespace BookCart.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetAll(CancellationToken ct);

    Task<Category?> GetById(int id, CancellationToken ct);

}
