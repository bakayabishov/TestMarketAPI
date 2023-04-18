using MarketApp.DataAccess.Repositories.Interfaces;

namespace MarketApp.Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IUsersRepository Users { get; }
        IProductsRepository Products { get; }
    }
}
