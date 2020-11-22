using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;

public class AzureTableLogger : ILogger
{
    private CloudTable loggingTable;

    public AzureTableLogger(string connectionString, string tableName)
    {
        var storageAccount = CloudStorageAccount.Parse(connectionString);
        var cloudTableClient = storageAccount.CreateCloudTableClient();

        loggingTable = cloudTableClient.GetTableReference(tableName);

        var result = loggingTable.ExistsAsync().Result;
        if (!result)
        {
            var output = "False";
        }

        loggingTable.CreateIfNotExistsAsync();
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        var log = new LogEntity
        {
            EventId = eventId.ToString(),
            LogLevel = logLevel.ToString(),
            Message = formatter(state, exception),//exception?.ToString(),
            PartitionKey = DateTime.Now.ToString("yyyyMMdd"),
            RowKey = Guid.NewGuid().ToString()
        };

        var insertOp = TableOperation.Insert(log);
        loggingTable.ExecuteAsync(insertOp).GetAwaiter().GetResult();
    }
}

public class LogEntity : TableEntity
{
    public string LogLevel { get; set; }
    public string EventId { get; set; }
    public string Message { get; set; }
}