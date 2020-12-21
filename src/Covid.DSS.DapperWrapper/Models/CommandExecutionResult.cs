using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.DapperWrapper.Models
{
    public class CommandExecutionResult
    {
        public DynamicParameters Parameters { get; set; }
        public int RowsAffected { get; set; }
    }
}
