using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Context;
using CustomerConnect.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.Application.Extensions
{
    public static class RepositoriesConfig
    {
        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>( context =>
            {
                context.UseSqlServer(configuration.GetConnectionString("CustomerConnectDb"));
            });

            services.AddTransient<IClientRepository, ClientRepository>();
        }
    }
}
