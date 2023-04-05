namespace TestAPIMarket.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
