using System.Linq.Expressions;
using Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
{
    protected readonly Context _ctx;
    protected DbSet<TEntity> _dbSet;

    public BaseRepository(Context ctx)
    {
        _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        _dbSet = _ctx.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? where = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (where != null)
        {
            query = query.Where(where);
        }

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> where,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _ctx.Set<TEntity>();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.FirstAsync(where);
    }

    public async Task<IEnumerable<TEntity>> GetAll(int page, int size,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _ctx.Set<TEntity>();

        // Incluir entidades relacionadas
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // Aplicar filtro se existir
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Aplicar ordenação se existir
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        // Paginação
        var result = query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return await result;
    }

    public virtual async Task Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _ctx.SaveChangesAsync();
     
    }
    
    public virtual async Task Add(IEnumerable<TEntity>? entity)
    {
        await _dbSet.AddRangeAsync(entity!);
        await _ctx.SaveChangesAsync();
     
    }

    public virtual async Task Alt(TEntity entity)
    {
        _ctx.Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public virtual async Task Alt(IList<TEntity> entity)
    {
        _ctx.UpdateRange(entity);
        await _ctx.SaveChangesAsync();
    }

    public virtual async Task Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _ctx.SaveChangesAsync();
    }
}