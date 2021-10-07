using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly DbContext _dbContext;
        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync<T>(int id) where T : class, IEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IQueryable<T>> GetAllAsync<T>() where T : class, IEntity
        {
            return await new Task<IQueryable<T>>(() => _dbContext.Set<T>());
        }
        public async Task<T> AddAsync<T>(T entity) where T : class, IEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync<T>(T entity) where T : class, IEntity
        {
            return await new Task<T>(() =>
            {
                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> temp = _dbContext.Entry(entity);
                temp.State = EntityState.Modified;
                _dbContext.SaveChangesAsync();
                return temp.Entity;
            });
        }
        public async Task<T> DeleteAsync<T>(T entity) where T : class, IEntity
        {
            T oldEntity = await new Task<T>(() => _dbContext.Set<T>().Remove(entity).Entity);
            await _dbContext.SaveChangesAsync();
            return oldEntity;
        }
    }
}
