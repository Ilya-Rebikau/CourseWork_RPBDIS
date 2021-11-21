using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.Services
{
    /// <summary>
    /// Base interface for all others
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class BaseService<T> : IServiceAsync<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _repository;
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
    }
}
