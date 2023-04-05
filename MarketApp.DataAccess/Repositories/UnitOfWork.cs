using MarketApp.DataAccess;
using TestAPIMarket.Data.Repositories.Interfaces;

namespace TestAPIMarket.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Property
        private readonly DataContext _context;
        private bool _disposed;
        #endregion

        #region Constructor
        public UnitOfWork(DataContext context) => this._context = context;
        #endregion

        #region Method
        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        protected virtual void Clean(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
