using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Data.Repo;

public interface IUnitOfWork
{
    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveAsync(CancellationToken cancellationToken);
}
