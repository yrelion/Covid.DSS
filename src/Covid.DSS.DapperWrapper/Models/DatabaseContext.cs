﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.DapperWrapper.Models
{
    public abstract class DatabaseContext<TSettings> : IDatabaseContext<TSettings> where TSettings : IDatabaseSettings
    {
        private bool _disposed;

        public IDbConnection Connection { get; set; }
        public ITransactionContext TransactionContext { get; set; }

        protected DatabaseContext(IConnectionFactory<TSettings> factory)
        {
            TransactionContext = new TransactionContext();
            Connection = Connection ?? factory.CreateFromSettings();
        }

        public abstract ITransactionContext BeginTransaction([CallerMemberName] string actionOriginator = null);
        public abstract TransactionStatus TryCommitTransaction(bool suppressOriginator = false, [CallerMemberName] string actionOriginator = null);
        public abstract TransactionStatus TryRollbackTransaction(bool suppressOriginator = false, [CallerMemberName] string actionOriginator = null);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Connection.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
