using System.Data.Common;

namespace CustomerConnect.Infrastructure.Database
{
    public sealed class DbSession : IDbSession
    {
        private readonly DbConnection _connection;
        public DbConnection Connection => _connection;

        public DbSession(DbConnection connection)
        {
            _connection = connection;
        }
    }
}
