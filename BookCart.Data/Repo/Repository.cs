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
