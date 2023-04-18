namespace Krista.Module.Common.DataAccess.Base.Entity; 

public abstract class EntityBase<TKey> : IEntityBase<TKey> {
    public abstract TKey GetId();
}