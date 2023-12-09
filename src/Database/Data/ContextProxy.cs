using Microsoft.Extensions.DependencyInjection;

namespace Database.Data;

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
