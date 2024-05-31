using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomerConnect.Infrastructure.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDbConnection Connection;
        private readonly IUnitOfWork Uow;

        public Repository(IUnitOfWork uow)
        {
            Uow = uow;
            Connection = uow.Connection;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var obj = Activator.CreateInstance<TEntity>();
            obj.Id = id;
            Uow.Context.Set<TEntity>().Remove(obj);
            await Uow.Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Uow.Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await Uow.Context.Set<TEntity>().AddAsync(entity);
            await Uow.Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Uow.Context.Set<TEntity>().Update(entity);
            await Uow.Context.SaveChangesAsync();

            return entity;
        }
    }
}
