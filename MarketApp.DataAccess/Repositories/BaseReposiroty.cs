using System.Linq.Expressions;
using Krista.Module.Common.DataAccess.Base.Entity;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class, IEntityBase<TKey>
    where TKey : notnull
{
    protected readonly DbContext Context;
    private DbSet<TEntity> _entities;
    public BaseRepository(DataContext context)
    {
        this.Context = context;
        this._entities = Context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression) =>
        await _entities.Where(expression).ToListAsync();

    public virtual IQueryable<TEntity> All => Context.Set<TEntity>();

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() {
        return await All.ToListAsync();
    }

    public async Task<TEntity?> DeleteAsync(TKey id) {
        var entity = await Context.FindAsync<TEntity>(id);
        if (entity != null)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        return entity;
    }

    public virtual TEntity Update(TEntity entity) {
        if (Context.Entry(entity).State == EntityState.Added)
        {
            return entity;
        }

        var localEntity = Context.Set<TEntity>().Local.FirstOrDefault(x => x.GetId().Equals(entity.GetId()));
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (localEntity != null && !ReferenceEquals(localEntity, entity))
        {
            Context.Set<TEntity>().Remove(localEntity);
            Context.Update(entity);
        }
        else
        {
            Context.Update(entity);
        }

        return entity;
    }

    public virtual async Task InsertAsync(TEntity entity) =>
        await _entities.AddAsync(entity);

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) {
        await Context.Set<TEntity>().AddRangeAsync(entities);
    }
}