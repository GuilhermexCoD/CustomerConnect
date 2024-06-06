using CustomerConnect.Application.Dtos;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;

namespace CustomerConnect.Application.Interfaces
{
    public interface IService<TDto, TEntity, TRepository>
                            where TDto : EntityDto
                            where TEntity : Entity
                            where TRepository : IRepository<TEntity>
    {
        TRepository Repository { get; }
        Task<IList<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> InsertAsync(TDto dto);
        Task<IEnumerable<TDto>> InsertRangeAsync(IEnumerable<TDto> dtos);
        Task<TDto> UpdateAsync(TDto dto);
        Task<IEnumerable<TDto>> UpdateRangeAsync(IEnumerable<TDto> dtos);
        Task DeleteAsync(Guid id);
    }
}
