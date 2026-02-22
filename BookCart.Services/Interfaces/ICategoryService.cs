using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using BookCart.Services.Models;

namespace BookCart.Services.Interfaces;

public interface ICategoryService
{
    Task<int> Create(CategoryModel model, CancellationToken ct);
    Task<IReadOnlyList<CategoryModel>> GetAll(CancellationToken ct);

    Task<CategoryModel?> GetById(int id, CancellationToken ct);

}
