using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using CustomerConnect.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
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

    }
}
