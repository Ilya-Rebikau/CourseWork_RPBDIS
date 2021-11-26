namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Repository
/// </summary>
public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Find entity by ID async
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>Entity</returns>
    Task<T> GetByIdAsync(int id);
    /// <summary>
    /// Get all entites async
    /// </summary>
    /// <returns>All entites</returns>
    Task<IQueryable<T>> GetAllAsync();
    /// <summary>
    /// Add new entity to database async
    /// </summary>
    /// <param name="entity">New entity</param>
    /// <returns>Added entity</returns>
    Task<T> AddAsync(T entity);
    /// <summary>
    /// Update entity in database async
    /// </summary>
    /// <param name="entity">Old entity</param>
    /// <returns>Updated entity</returns>
    Task<T> UpdateAsync(T entity);
    /// <summary>
    /// Update entity in database by id async
    /// </summary>
    /// <param name="id">ID of updating entity</param>
    /// <returns>Updated entity</returns>
    Task<T> UpdateByIdAsync(int id);
    /// <summary>
    /// Delete entity from database async
    /// </summary>
    /// <param name="entity">Deleting entity</param>
    /// <returns>Deleted entity</returns>
    Task<T> DeleteAsync(T entity);
    /// <summary>
    /// Delete entity from database by id async
    /// </summary>
    /// <param name="id">ID of deleting entity</param>
    /// <returns>Deleted entity</returns>
    Task<T> DeleteByIdAsync(int id);
}
