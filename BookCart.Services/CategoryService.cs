using BookCart.Data.Entities;
using BookCart.Data.Repo;

namespace BookCart.Services;

public class CategoryService(IRepository<Category> repo) : ICategoryService
{
    private readonly IRepository<Category> _repo = repo;

    public async Task<IReadOnlyList<Category>> GetAll(CancellationToken ct)
    {
        return await _repo.GetAllAsync(ct);
    }

    public async Task<Category?> GetById(int id, CancellationToken ct)
    {
        return await _repo.GetByIdAsync(id, ct);
    }
}
