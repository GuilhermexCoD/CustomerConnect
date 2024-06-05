using AutoMapper;
using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.Application.Services
{
    public class Service<TDto, TEntity, TRepository> : IService<TDto, TEntity, TRepository>
                                                                where TEntity : Entity
                                                                where TDto : EntityDto
                                                                where TRepository : IRepository<TEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TRepository Repository => (TRepository)_repository;

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<IList<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<TDto>>(entities);
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> InsertAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            entity = await _repository.InsertAsync(entity);

            dto.Id = entity.Id;

            return dto;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.UpdateAsync(entity);

            return dto;
        }
    }
}
