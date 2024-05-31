using CustomerConnect.Application.Dtos;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;

namespace CustomerConnect.Application.Interfaces
{
    public interface IService<TDto, TEntity, TRepository>
                            where TEntity : Entity
                            where TDto : EntityDto
                            where TRepository : IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> InsertAsync(TDto dto);
        Task<TEntity> UpdateAsync(TDto dto);
        Task DeleteAsync(Guid id);
    }
}
