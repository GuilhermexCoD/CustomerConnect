using AutoMapper;
using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.Application.Services
{
    public class ClientService : Service<ClientDto, Client, IClientRepository>, IClientService
    {
        public ClientService(IClientRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<ClientDto>> GetAll(bool includePhones = false)
        {
            List<Client>? clients = null;

            if (includePhones)
                clients = await _repository.GetAll().Include(c => c.Phones).ToListAsync();
            else
                clients = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<ClientDto>>(clients);
        }

        public override async Task<ClientDto?> GetByIdAsync(Guid id)
        {
            var client = await _repository.GetById(id).Include(c => c.Phones).FirstOrDefaultAsync();

            return _mapper.Map<ClientDto>(client);
        }
    }
}
