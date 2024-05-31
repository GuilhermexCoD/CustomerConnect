using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;

namespace CustomerConnect.Application.Services
{
    public class ClientService : IClientService
    {
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> InsertAsync(ClientDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateAsync(ClientDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
