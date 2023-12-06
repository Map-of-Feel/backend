using System.Collections;
using System.Linq.Expressions;

using Database.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Data;

public sealed class MapOfFeelContext : IdentityDbContext<AppUser>
{
    public DbSet<Emotion> Emotions { get; set; }

    public MapOfFeelContext(DbContextOptions<MapOfFeelContext> options)
       : base(options)
    { }
}

public interface IRepo<T> : IQueryable<T>, IAsyncEnumerable<T>
    where T : class
{
    MapOfFeelContext Context { get; }
}

public interface IContextProxy
{
    IRepo<T> GetRepo<T>()
        where T : class;
}

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

internal sealed class ContextProxy : IContextProxy
{
    private readonly IServiceProvider _serviceProvider;

    public ContextProxy(
        MapOfFeelContext context,
        IServiceProvider serviceProvider)
    {
        Context = context;
        _serviceProvider = serviceProvider;
    }

    public MapOfFeelContext Context { get; init; }

    public IRepo<T> GetRepo<T>()
        where T : class
    {
        return _serviceProvider.GetRequiredService<IRepo<T>>();
    }
}