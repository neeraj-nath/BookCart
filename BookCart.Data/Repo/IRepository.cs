using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Data.Repo;

public interface IRepository<T>
{
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct);

    Task<T?> GetByIdAsync(int id, CancellationToken ct);

    IQueryable<T> Query();
}
