using Microsoft.Extensions.Logging;

public class AzureTableLoggerProvider : ILoggerProvider
{
    private readonly string connectionStringName;
    private readonly string tableName;

    public AzureTableLoggerProvider(string connectionString, string tableName)
    {
        connectionStringName = connectionString;
        this.tableName = tableName;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new AzureTableLogger(connectionStringName, tableName);
    }

    public void Dispose()
    {
    }
}