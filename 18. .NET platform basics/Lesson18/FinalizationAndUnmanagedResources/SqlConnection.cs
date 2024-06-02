using System.Data;
using System.Data.Common;

namespace FinalizationAndUnmanagedResources;

public class SqlConnection(string path) : DbConnection
{
    private readonly string _path = path;

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }

    public override void ChangeDatabase(string databaseName)
    {
    }

    public override void Close()
    {
        Console.WriteLine("Connection closed");
    }

    public override void Open()
    {
        Console.WriteLine("Connection opened");
    }

    public override string ConnectionString { get; set; }
    public override string Database { get; }
    public override ConnectionState State { get; }
    public override string DataSource { get; }
    public override string ServerVersion { get; }

    protected override DbCommand CreateDbCommand()
    {
        throw new NotImplementedException();
    }
}