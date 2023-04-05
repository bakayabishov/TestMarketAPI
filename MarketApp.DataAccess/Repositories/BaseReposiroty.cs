using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestAPIMarket.Data.Repositories.Interfaces;

namespace MarketApp.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Property
        protected readonly DataContext Context;
        private DbSet<TEntity> _entities;
        #endregion

        #region Constructor
        public BaseRepository(DataContext context)
        {
            this.Context = context;
            this._entities = Context.Set<TEntity>();
        }
        #endregion

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression) =>
            await _entities.Where(expression).ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int entityId) =>
            await _entities.Where(entity => EF.Property<int>(entity, "Id").Equals(entityId)).SingleOrDefaultAsync();

        public virtual async Task InsertAsync(TEntity entity) =>
            await _entities.AddAsync(entity);

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
            await _entities.AddRangeAsync(entities);

        public virtual void AttachRange(IEnumerable<TEntity> entities) =>
            _entities.AttachRange(entities);
    }
}
