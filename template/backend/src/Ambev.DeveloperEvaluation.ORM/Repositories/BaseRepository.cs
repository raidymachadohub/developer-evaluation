using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IBaseRepository 
/// </summary>
/// <param name="context"></param>
/// <typeparam name="T"></typeparam>
public class BaseRepository<T>(DefaultContext context) : IBaseRepository<T> where T: BaseEntity
{
    /// <inheritdoc />
    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetAllAsync(string[] includes, CancellationToken cancellationToken = default)
    {
        var dbSet = context.Set<T>();
        var db = includes.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));

        return await db.ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<T?> GetByIdAsync(Guid id, string[] includes, CancellationToken cancellationToken = default)
    {
        var dbSet = context.Set<T>();
        var db = includes.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));
        
        return await db.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return false;

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}