namespace Database.Data;

public interface IRepo<T> : IQueryable<T>, IAsyncEnumerable<T>
    where T : class
{
    MapOfFeelContext Context { get; }
}
