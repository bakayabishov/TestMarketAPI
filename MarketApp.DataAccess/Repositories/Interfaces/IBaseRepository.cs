namespace TestAPIMarket.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int entityId);
        Task InsertAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void AttachRange(IEnumerable<TEntity> entities);
    }
}
