using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CustomerConnect.Infrastructure.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var obj = Activator.CreateInstance<TEntity>();
            obj.Id = id;
            _context.Set<TEntity>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> GetById(Guid id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id).AsQueryable();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var groupEntities = entities.GroupBy(x => x.Id == Guid.Empty);
            var insertEntities = groupEntities.FirstOrDefault(x => x.Key)?.ToList();
            var updateEntities = groupEntities.FirstOrDefault(x => !x.Key)?.ToList();

            var resultEntities = new List<TEntity>(entities.Count());

            if (insertEntities != null)
            {
                foreach (var entity in insertEntities)
                {
                    var insertResult = await InsertAsync(entity);
                    resultEntities.Add(insertResult);
                }
            }

            if (updateEntities != null)
            {
                _context.Set<TEntity>().UpdateRange(updateEntities);
                resultEntities.AddRange(updateEntities);
            }

            await _context.SaveChangesAsync();

            return resultEntities;
        }
    }
}
