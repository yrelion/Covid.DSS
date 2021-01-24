using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Resources;

namespace Covid.DSS.Common.Models
{
    /// <summary>
    /// Represents generic API related exceptions when no other <see cref="DssException"/> is appropriate
    /// </summary>
    public class DssException : Exception
    {
        public DssException(string message) : base(message) { }
    }

    /// <summary>
    /// Represents an error of unknown cause. Typically used as a bare-bone <see cref="Exception"/> alternative
    /// without the extra info it carries
    /// </summary>
    public class UnknownErrorException : DssException
    {
        public UnknownErrorException() : base(Exceptions.UnknownError) { }
    }

    /// <summary>
    /// Represents an error of a database transaction
    /// </summary>
    public class TransactionFailureException : DssException
    {
        public TransactionFailureException() : base(Exceptions.TransactionFailure) { }
    }

    /// <summary>
    /// Represents an incomplete database operation
    /// </summary>
    public class IncompleteDatabaseOperationException : DssException
    {
        public IncompleteDatabaseOperationException() : base(Exceptions.IncompleteDatabaseOperation) { }
    }

    /// <summary>
    /// Represents an error of database querying
    /// </summary>
    public class InternalDatabaseException : DssException
    {
        public InternalDatabaseException() : base(Exceptions.InternalDatabase) { }
    }

    /// <summary>
    /// Represents an error of non-existent data
    /// </summary>
    public class NoDataFoundException : DssException
    {
        public NoDataFoundException() : base(Exceptions.NoDataFound) { }
    }

    /// <summary>
    /// Represents an error of file creation or manipulation
    /// </summary>
    public class FileManipulationException : DssException
    {
        public FileManipulationException() : base(Exceptions.FileManipulation) { }
    }

    /// <summary>
    /// Represents an error of unexpected values
    /// </summary>
    public class UnexpectedValuesException : DssException
    {
        public UnexpectedValuesException() : base(Exceptions.UnexpectedValues) { }
    }
}
