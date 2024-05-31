using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Base;

namespace CustomerConnect.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client> , IClientRepository
    {
        public ClientRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
