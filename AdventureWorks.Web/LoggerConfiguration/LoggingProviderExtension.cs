using Microsoft.Extensions.Logging;

public static class AzureTableLoggerExtensions
{
    public static ILoggerFactory AddTableStorage(this ILoggerFactory loggerFactory, string tableName, string connectionString)
    {
        loggerFactory.AddProvider(new AzureTableLoggerProvider(connectionString, tableName));
        return loggerFactory;
    }
}