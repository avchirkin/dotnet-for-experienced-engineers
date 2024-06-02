using System.Collections.Concurrent;

namespace FinalizationAndUnmanagedResources;

public class SqlConnectionsManager(int id) : IDisposable
{
    private readonly ConcurrentDictionary<string, SqlConnection> _connections = new();
    private readonly int _id = id;

    public SqlConnection Open(string path)
    {
        if (!_connections.TryGetValue(path, out var connection))
        {
            connection = new SqlConnection(path);
            _connections[path] = connection;
        }
        
        return connection;
    }

    // Освобождаем подключения. Метод Dispose будет вызван в финализаторе или явно из кода приложения
    protected virtual void Dispose(bool disposing)
    {
        Console.WriteLine($"Manager {_id}. Protected Dispose called. disposing = {disposing}");
        
        // Очищаем managed-ресурсы
        if (disposing)
        {
            foreach (var (_, conn) in _connections)
            {
                conn.Dispose();
            }
        }
        
        // Очищаем unmanaged-ресурсы (streams, handles и пр.)
    }

    public void Dispose()
    {
        Console.WriteLine($"Manager {_id}. Public Dispose called");
        
        Dispose(true);
        
        // Указываем CLR не вызывать финализатор - очистка уже произведена
        GC.SuppressFinalize(this);
    }

    ~SqlConnectionsManager()
    {
        Console.WriteLine($"Manager {_id}. Finalizer has been called");
        Dispose(false);
    }
}