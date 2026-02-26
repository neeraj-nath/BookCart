using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Data.Repo;

public interface IRepository<T>
{
    Task Create(T entity, CancellationToken ct);

    [Obsolete("This method attaches the entire entity as modified. Therefore is not a safe way to update. Instead we should load + modify + save entity")]
    Task Update(T entity, CancellationToken _);

    void Delete(T entity, CancellationToken ct);

    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct);

    Task<T?> GetByIdAsync(int id, CancellationToken ct);

    IQueryable<T> Query();
}
