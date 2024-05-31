using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomerConnect.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        DbContext Context { get; set; }
        void BeginTransaction();
        void Commit(bool dispose = true);
        void Rollback(bool dispose = true);
    }
}
