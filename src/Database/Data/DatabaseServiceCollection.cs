using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Database.Data
{
    public static class DatabaseServiceCollection
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MapOfFeelContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("MapOfFeelContext")));

            services.TryAddTransient<IContextProxy, ContextProxy>();

            services.TryAddTransient(typeof(IRepo<>), typeof(Repo<>));

            return services;
        }
    }
}