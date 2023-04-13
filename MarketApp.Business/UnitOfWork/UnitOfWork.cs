using MarketApp.DataAccess;
using MarketApp.DataAccess.Repositories.Interfaces;

namespace MarketApp.Business.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Property
        private readonly DataContext _context;
        private bool _disposed;
        #endregion

        #region Constructor
        public UnitOfWork(DataContext context, IUsersRepository users) {
            this._context = context;
            Users = users;
        }
        #endregion

        #region Method
        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public IUsersRepository Users { get; }

        private void Clean(bool disposing)
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
