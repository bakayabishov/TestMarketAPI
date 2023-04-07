using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Tests.MarketApp.Integration
{
    public abstract class TestWithDb<T> : IDisposable where T : DbContext
    {
        private const string ConnectionString = "server=localhost;database=marketAPI;trusted_connection=true;Encrypt=false";
        private readonly SqlConnection  _connection;
        protected DbContextOptions<T> Options { get; }

        protected TestWithDb()
        {
            this._connection = new SqlConnection(ConnectionString);
            this._connection.Open();
            this.Options = new DbContextOptionsBuilder<T>().UseSqlServer(_connection).Options;
        }

        public void Dispose() => _connection.Close();
    }
}
