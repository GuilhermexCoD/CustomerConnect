using CustomerConnect.Domain.Interfaces;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Context;
using CustomerConnect.Infrastructure.Database;
using CustomerConnect.Infrastructure.Repositories;
using CustomerConnect.Infrastructure.UoW;
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

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbSession, DbSession>();
            services.AddTransient<IClientRepository, ClientRepository>();
        }
    }
}
