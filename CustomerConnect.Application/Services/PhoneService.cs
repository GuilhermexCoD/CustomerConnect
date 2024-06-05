using AutoMapper;
using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;

namespace CustomerConnect.Application.Services
{
    public class PhoneService : Service<PhoneDto, Phone, IPhoneRepository>, IPhoneService
    {
        public PhoneService(IPhoneRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
