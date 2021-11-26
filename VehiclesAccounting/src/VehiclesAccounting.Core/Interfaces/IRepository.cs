namespace VehiclesAccounting.Core.Interfaces
{
    /// <summary>
    /// Interface of repository
    /// </summary>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Async method to find entity by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Entity</returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Async method to get all entites
        /// </summary>
        /// <returns>All entites</returns>
        Task<IQueryable<T>> GetAllAsync();
        /// <summary>
        /// Async method to add new entity to database
        /// </summary>
        /// <param name="entity">New entity</param>
        /// <returns>Added entity</returns>
        Task<T> AddAsync(T entity);
        /// <summary>
        /// Async method to update entity in database
        /// </summary>
        /// <param name="entity">Old entity</param>
        /// <returns>Task</returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// Async method to update entity in database by id
        /// </summary>
        /// <param name="id">ID of updating entity</param>
        /// <returns>Task</returns>
        Task<T> UpdateByIdAsync(int id);
        /// <summary>
        /// Async method to delete entity from database
        /// </summary>
        /// <param name="entity">Deleting entity</param>
        /// <returns>Deleted entity</returns>
        Task<T> DeleteAsync(T entity);
        /// <summary>
        /// Async method to delete entity from database by id
        /// </summary>
        /// <param name="id">ID of deleting entity</param>
        /// <returns>Deleted entity</returns>
        Task<T> DeleteByIdAsync(int id);
    }
}
