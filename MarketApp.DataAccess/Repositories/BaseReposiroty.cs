using System.Linq.Expressions;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity> where TEntity : class
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

        public virtual async Task<TEntity> GetByIdAsync(TKey id) {
            var result = await Context.FindAsync<TEntity>(id);
            if (result == null) {
                throw new Exception();
            }

            return result;
        }
        public virtual IQueryable<TEntity> All => Context.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await All.ToListAsync();
        }

        public virtual async Task<TEntity?> DeleteAsync(TKey id) {
            var entity = await Context.FindAsync<TEntity>(id);
            if (entity != null) {
                Context.Set<TEntity>().Remove(entity);
            }

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity) =>
            await _entities.AddAsync(entity);

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
