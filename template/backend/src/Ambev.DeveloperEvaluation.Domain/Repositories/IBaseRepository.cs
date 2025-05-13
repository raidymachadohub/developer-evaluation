using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// This is a generic base repository interface.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Create a new entity in the repository
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    ///  Update an existing entity in the repository
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    ///  Get all entities from the repository
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get all entities from the repository with a given predicate
    /// </summary>
    /// <param name="includes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync(string[] includes, CancellationToken cancellationToken = default);
    
    /// <summary>
    ///  Get all entities from the repository that match a given predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    
    /// <summary>
    ///  Get an entity by its unique identifier with includes
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id,string[] includes, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get an entity by its unique identifier without includes
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    ///  Get an entity by a given predicate
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}