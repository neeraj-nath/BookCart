using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using BookCart.Data.Context;

namespace BookCart.Data.Repo;

public class UnitOfWork(BookCartDbContext db, IServiceProvider provider) : IUnitOfWork
{
    private readonly BookCartDbContext _db = db;
    private readonly IServiceProvider _provider = provider;
    //public IRepository<Category> Category { get; } = category; //Repository exposed as property

    public IRepository<T> Repository<T>() where T : class
    {
        return _provider.GetRequiredService<IRepository<T>>();
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }

}
