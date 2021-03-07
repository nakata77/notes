using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ATP.MyNotesApp.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
            where TEntity : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationDbContext ApplicationContext => _dbContext as ApplicationDbContext;

        public async Task<TEntity> GetAsync(int id)
            => await ApplicationContext.Set<TEntity>()
                .FindAsync(id);

        public async Task<TEntity> GetAsync(Guid id)
            => await ApplicationContext.Set<TEntity>()
                .FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await ApplicationContext.Set<TEntity>()
                .ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await ApplicationContext.Set<TEntity>()
                .Where(predicate)
                .ToListAsync();

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await ApplicationContext.Set<TEntity>()
                .FirstOrDefaultAsync(predicate);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await ApplicationContext.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public void Add(TEntity entity)
        {
            ApplicationContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ApplicationContext.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            ApplicationContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ApplicationContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            ApplicationContext.Set<TEntity>().Update(entity);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            ApplicationContext.Set<TEntity>().AttachRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            ApplicationContext.Set<TEntity>().UpdateRange(entities);
        }

        public Task SaveChangesAsync()
            => ApplicationContext.SaveChangesAsync();
    }
}
