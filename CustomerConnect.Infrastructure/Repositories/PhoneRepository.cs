using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Base;
using CustomerConnect.Infrastructure.Context;

namespace CustomerConnect.Infrastructure.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DatabaseContext context) : base(context) { }
    }
}
