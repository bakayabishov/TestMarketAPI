namespace MarketApp.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        IQueryable<TEntity> All { get; }

    }
}
