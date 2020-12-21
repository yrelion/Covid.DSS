using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace Covid.DSS.DapperWrapper.Interfaces
{
    public interface IDatabaseContext<out TSettings> : IDisposable where TSettings : IDatabaseSettings
    {
        IDbConnection Connection { get; set; }
        ITransactionContext TransactionContext { get; }
        ITransactionContext BeginTransaction([CallerMemberName] string actionOriginator = null);
        TransactionStatus TryCommitTransaction(bool suppressOriginator = false, [CallerMemberName] string actionOriginator = null);
        TransactionStatus TryRollbackTransaction(bool suppressOriginator = false, [CallerMemberName] string actionOriginator = null);
    }
}
