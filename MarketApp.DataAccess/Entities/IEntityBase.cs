namespace Krista.Module.Common.DataAccess.Base.Entity;

public interface IEntityBase<TKey> {
    TKey GetId();
}