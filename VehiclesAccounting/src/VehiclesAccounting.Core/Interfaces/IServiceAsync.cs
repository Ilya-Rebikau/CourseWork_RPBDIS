namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Base services with CRUD operations
/// </summary>
/// <typeparam name="T">Entity</typeparam>
public interface IServiceAsync<T> where T : class, IEntity
{
    /// <summary>
    /// Read all entities from database async
    /// </summary>
    /// <returns>All entites</returns>
    Task<IEnumerable<T>> ReadAllAsync();
    /// <summary>
    /// Update entity in database async
    /// </summary>
    /// <param name="entity">Updating entity</param>
    /// <returns>New entity</returns>
    Task<T> UpdateAsync(T entity);
    /// <summary>
    /// Update entity in database async by id
    /// </summary>
    /// <param name="id">ID of updating entity</param>
    /// <returns>New entity</returns>
    Task<T> UpdateByIdAsync(int id);
    /// <summary>
    /// Delete entity in database async
    /// </summary>
    /// <param name="entity">Deleting entity</param>
    /// <returns>Old entity</returns>
    Task<T> DeleteAsync(T entity);
    /// <summary>
    /// Delete entity in database async by id
    /// </summary>
    /// <param name="id">ID of deleting entity</param>
    /// <returns>Old entity</returns>
    Task<T> DeleteAsyncById(int id);
    /// <summary>
    /// Add new entity to database
    /// </summary>
    /// <param name="entity">New entity</param>
    /// <returns>Added entity</returns>
    Task<T> AddAsync(T entity);
    /// <summary>
    /// Async method to find entity by ID
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>Entity</returns>
    Task<T> GetByIdAsync(int id);
}
