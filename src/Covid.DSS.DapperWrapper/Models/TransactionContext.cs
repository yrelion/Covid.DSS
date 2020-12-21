using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.DapperWrapper.Models
{
    public class TransactionContext : ITransactionContext
    {
        public string OriginatorName { get; set; }
        public IDbTransaction Transaction { get; set; }
        public TransactionStatus Status { get; set; }
        public List<string> Errors { get; }

        public TransactionContext()
        {
            Errors = new List<string>();
        }
    }
}
