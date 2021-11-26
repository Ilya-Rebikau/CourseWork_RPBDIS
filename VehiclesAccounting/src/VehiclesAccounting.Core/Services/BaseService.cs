using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.Services
{
    /// <summary>
    /// Base realization of IServiceAsync
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class BaseService<T> : IServiceAsync<T> where T : class, IEntity
    {
        protected IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            IQueryable<T>? results = await _repository.GetAllAsync();
            return await Task.Run(() => results.AsEnumerable());
        }
        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public async Task<T> DeleteAsync(T entity)
        {
            return await _repository.DeleteAsync(entity);
        }
        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<T> UpdateByIdAsync(int id)
        {
            return await _repository.UpdateByIdAsync(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> DeleteAsyncById(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
