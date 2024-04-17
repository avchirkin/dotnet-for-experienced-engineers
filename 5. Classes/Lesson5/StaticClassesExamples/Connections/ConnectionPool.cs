namespace StaticClassesExamples.Connections
{
    internal static class ConnectionPool
    {
        private static Dictionary<string, DbConnection> _connections = [];

        public static DbConnection GetOrCreate(string name, string? path = null)
        {
            if (!_connections.TryGetValue(name, out DbConnection? conn))
            {
                if (path == null)
                {
                    ArgumentNullException.ThrowIfNull(nameof(path));
                }

                conn = new DbConnection(name, path!);
                _connections[name] = conn;
            }

            return conn;
        }
    }
}
