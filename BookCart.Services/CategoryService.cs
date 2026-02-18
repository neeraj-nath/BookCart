using BookCart.Data.Entities;
using BookCart.Data.Repo;
using BookCart.Services.Extensions;
using BookCart.Services.Models;

namespace BookCart.Services;

public class CategoryService(IRepository<Category> repo) : ICategoryService
{
    private readonly IRepository<Category> _repo = repo;

    public async Task<IReadOnlyList<CategoryModel>> GetAll(CancellationToken ct)
    {
        var entities = await _repo.GetAllAsync(ct);
        return entities.ToModels();
    }

    public async Task<CategoryModel?> GetById(int id, CancellationToken ct)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity?.ToModel();
    }
}
