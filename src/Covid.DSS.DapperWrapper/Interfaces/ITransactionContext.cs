using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace Covid.DSS.DapperWrapper.Interfaces
{
    public interface ITransactionContext
    {
        string OriginatorName { get; set; }
        IDbTransaction Transaction { get; set; }
        TransactionStatus Status { get; set; }
        List<string> Errors { get; }
    }
}
