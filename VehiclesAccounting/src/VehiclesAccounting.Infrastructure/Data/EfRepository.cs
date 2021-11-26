using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext _dbContext;
        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() => _dbContext.Set<T>());
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() =>
            {
                EntityEntry<T> temp = _dbContext.Entry(entity);
                temp.State = EntityState.Modified;
                _dbContext.SaveChanges();
                return temp.Entity;
            });
        }
        public async Task<T> UpdateByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                T entity = _dbContext.Set<T>().SingleOrDefault(x => x.Id == id);
                EntityEntry<T> temp = _dbContext.Entry(entity);
                temp.State = EntityState.Modified;
                _dbContext.SaveChanges();
                return temp.Entity;
            });
        }
        public async Task<T> DeleteAsync(T entity)
        {
            T oldEntity = await Task.Run(() => _dbContext.Set<T>().Remove(entity).Entity);
            await _dbContext.SaveChangesAsync();
            return oldEntity;
        }

        public async Task<T> DeleteByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                T entity = _dbContext.Set<T>().SingleOrDefault(x => x.Id == id);
                EntityEntry<T> temp = _dbContext.Entry(entity);
                temp.State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return temp.Entity;
            });
        }
    }
}
