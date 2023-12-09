using System.Collections;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Database.Data;

internal sealed class Repo<T> : IRepo<T>
    where T : class
{
    private readonly DbSet<T> _dbSet;

    public Repo(MapOfFeelContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }

    public MapOfFeelContext Context { get; }

    public Type ElementType => _dbSet.AsQueryable().ElementType;

    public Expression Expression => _dbSet.AsQueryable().Expression;

    public IQueryProvider Provider => _dbSet.AsQueryable().Provider;

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => _dbSet.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);

    public IEnumerator<T> GetEnumerator() => _dbSet.AsQueryable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _dbSet.AsQueryable().GetEnumerator();
}
