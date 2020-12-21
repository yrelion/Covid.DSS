using System.Data;

namespace Covid.DSS.DapperWrapper.Interfaces
{
    public interface IConnectionFactory<TSettings> where TSettings : IDatabaseSettings
    {
        IDbConnection Create(string connectionString);
        IDbConnection CreateFromSettings();
    }
}
