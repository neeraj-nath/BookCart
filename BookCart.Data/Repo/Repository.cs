using BookCart.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Data.Repo;

public class Repository<T>(BookCartDbContext context) : IRepository<T> where T : class
{
    private readonly BookCartDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

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
