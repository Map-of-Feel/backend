using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Npgsql;

namespace Database.Data
{
    public static class DatabaseServiceCollection
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);

            services.AddDbContext<MapOfFeelContext>(options =>
               options.UseNpgsql(connectionString));

            services.TryAddTransient<IContextProxy, ContextProxy>();

            services.TryAddTransient(typeof(IRepo<>), typeof(Repo<>));

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.GetSection("POSTGRES_HOST").Value,
                Database = configuration.GetSection("POSTGRES_DB").Value,
                Username = configuration.GetSection("POSTGRES_USER").Value,
                Password = configuration.GetSection("POSTGRES_PASSWORD").Value,
            };

            var connectionString = connectionStringBuilder.ToString();

            return connectionString;
        }
    }
}