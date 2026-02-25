using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using BookCart.Data.Context;

namespace BookCart.Data.Repo;

public class Repository<T>(BookCartDbContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task Create(T entity, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _dbSet.AddAsync(entity, ct);
    }

    [Obsolete("This method attaches the entire entity as modified. Therefore is not a safe way to update. Instead we should load + modify + save entity")]
    public async Task Update(T entity, CancellationToken _)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _dbSet.Update(entity);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct)
    {
        return await _dbSet.AsNoTracking().ToListAsync(ct);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _dbSet.FindAsync([id], cancellationToken : ct);
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsNoTracking();
    }

}
