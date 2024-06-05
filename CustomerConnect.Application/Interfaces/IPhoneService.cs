using CustomerConnect.Application.Dtos;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;

namespace CustomerConnect.Application.Interfaces
{
    public interface IPhoneService : IService<PhoneDto, Phone, IPhoneRepository>
    {

    }
}
