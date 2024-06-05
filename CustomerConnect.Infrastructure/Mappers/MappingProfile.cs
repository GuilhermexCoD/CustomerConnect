using AutoMapper;
using CustomerConnect.Application.Dtos;
using CustomerConnect.Domain.Entities;

namespace CustomerConnect.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<Phone, PhoneDto>().ReverseMap();
        }
    }
}
