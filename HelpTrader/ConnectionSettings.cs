using bgTeam.DataAccess;

namespace HelpTrader;

public class ConnectionSettings : IConnectionSetting
{
    public ConnectionSettings(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("PSQLDb");
    }

    public string ConnectionString { get; set; }
}