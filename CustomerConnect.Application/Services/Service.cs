using AutoMapper;
using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;

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

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> InsertAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                return await _repository.InsertAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
