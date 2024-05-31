using System.Data.Common;

namespace CustomerConnect.Infrastructure.Database
{
    public interface IDbSession
    {
        DbConnection Connection { get; }
    }
}
