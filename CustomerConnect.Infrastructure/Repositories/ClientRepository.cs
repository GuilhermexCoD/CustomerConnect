using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Base;
using CustomerConnect.Infrastructure.Context;

namespace CustomerConnect.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DatabaseContext context) : base(context) { }
    }
}
