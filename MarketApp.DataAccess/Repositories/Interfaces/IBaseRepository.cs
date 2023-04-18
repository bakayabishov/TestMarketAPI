namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IBaseRepository { }

public interface IBaseRepository<TEntity, in TKey> : IBaseRepository where TEntity : class
{
    Task InsertAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    IQueryable<TEntity> All { get; }
    TEntity Update(TEntity entity);
}