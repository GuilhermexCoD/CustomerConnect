using CustomerConnect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using System.Data.Common;

namespace CustomerConnect.Infrastructure.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IDbConnection Connection { get; set; }
        public DbContext Context { get; set; }
        public IDbTransaction Transaction { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            Context.Database.OpenConnection();
            Connection = Context.Database.GetDbConnection();

        }
        public void BeginTransaction()
        {
            var transactionContext = Context.Database.BeginTransaction();
            Transaction = (transactionContext as IInfrastructure<DbTransaction>).Instance;
        }

        public void Commit(bool dispose = true)
        {
            Transaction.Commit();

            if (dispose)
                Dispose();
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            
                Connection.Dispose();
            }

            Transaction?.Dispose();

            Context?.Dispose();
        }

        public void Rollback(bool dispose = true)
        {
            Transaction.Rollback();

            if (dispose)
                Dispose();
        }
    }
}
