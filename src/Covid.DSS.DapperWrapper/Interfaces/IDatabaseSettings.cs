namespace Covid.DSS.DapperWrapper.Interfaces
{
    public interface IDatabaseSettings
    {
        string Username { get; set; }
        string Password { get; set; }
        string ConnectionString { get; set; }
    }
}
