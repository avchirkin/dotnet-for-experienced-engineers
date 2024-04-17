namespace StaticClassesExamples.Connections
{
    internal class DbConnection
    {
        public string ConnectionName { get; }
        public string ConnectionPath { get; }

        public DbConnection(string name, string path)
        {
            ConnectionName = name;
            ConnectionPath = path;
        }
    }
}
