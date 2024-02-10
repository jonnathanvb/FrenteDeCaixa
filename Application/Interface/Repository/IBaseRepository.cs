using System.Linq.Expressions;

namespace Application.Interface.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object>>[] includes);

    Task<IEnumerable<TEntity>> GetAll(
        int page, int size,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    
    // ------- COMMAND --------  //
    
    Task Add(TEntity entity);
    Task Add(IEnumerable<TEntity>? entity);
    Task Alt(TEntity entity);
    Task Alt(IList<TEntity> entity);
    
    Task Remove(TEntity entity);
}