using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using BookCart.Data.Entities;
using BookCart.Data.Repo;
using BookCart.Services.Extensions;
using BookCart.Services.Interfaces;
using BookCart.Services.Models;

namespace BookCart.Services.Services;

public class CategoryService(IUnitOfWork work) : ICategoryService
{
    //private readonly IRepository<Category> _repo = repo;
    private readonly IUnitOfWork _work = work;
    private readonly IRepository<Category> _repo = work.Repository<Category>();

    public async Task<int> Create(CategoryModel model, CancellationToken ct)
    {
        Category entity = new(){ Name = model.Name, DisplayOrder = model.DisplayOrder };

        await _repo.Create(entity, ct);
        return await _work.SaveAsync(ct);
    }

    public async Task<int> Update(CategoryModel model, CancellationToken ct)
    {
        Category entity = await _repo.GetByIdAsync(model.Id, ct) ?? throw new KeyNotFoundException($"Category with Id:{model.Id} not found");

        entity.Name = model.Name;
        entity.DisplayOrder = model.DisplayOrder;

        return await _work.SaveAsync(ct);
    }

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
