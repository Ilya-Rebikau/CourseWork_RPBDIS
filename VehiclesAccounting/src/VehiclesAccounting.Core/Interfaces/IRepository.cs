using System.Linq;
using System.Threading.Tasks;

namespace VehiclesAccounting.Core.Interfaces
{
    /// <summary>
    /// Interface of repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Async method to find entity by ID
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">ID</param>
        /// <returns>Entity</returns>
        Task<T> GetByIdAsync<T>(int id) where T : class, IEntity;
        /// <summary>
        /// Async method to get all entites
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <returns>All entites</returns>
        Task<IQueryable<T>> GetAllAsync<T>() where T : class, IEntity;
        /// <summary>
        /// Async method to add new entity to database
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">New entity</param>
        /// <returns>Added entity</returns>
        Task<T> AddAsync<T>(T entity) where T : class, IEntity;
        /// <summary>
        /// Async method to update entity in database
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Old entity</param>
        /// <returns>Task</returns>
        Task UpdateAsync<T>(T entity) where T : class, IEntity;
        /// <summary>
        /// Async method to delete entity from database
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Deleting entity</param>
        /// <returns>Task</returns>
        Task DeleteAsync<T>(T entity) where T : class, IEntity;
    }
}
