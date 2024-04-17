using StaticClassesExamples.Connections;
using StaticClassesExamples.Singletones;

var singletoneLogger = Singletone<ConsoleLogger>.Instance;
singletoneLogger.Log("Hi from logger!");

var conn1 = ConnectionPool.GetOrCreate("products", "products.db");
var conn2 = ConnectionPool.GetOrCreate("products");

Console.WriteLine(object.ReferenceEquals(conn1, conn2)); // true

