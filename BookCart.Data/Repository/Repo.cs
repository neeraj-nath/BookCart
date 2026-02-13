using BookCart.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookCart.Data.Repository;

public class Repo<T>(BookCartDbContext context) : IRepo<T> where T : class
{
    private readonly BookCartDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }
}
