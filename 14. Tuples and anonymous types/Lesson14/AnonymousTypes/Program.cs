// Анонимные типы - это типы без названия, используемые, как правило, в месте своего объявления для локальных операций

using AnonymousTypes;

var instanceOne = new {Id = 42, Name = "Mikhail"};
Console.WriteLine(instanceOne); // { Id = 42, Name = Mikhail }
Console.WriteLine(instanceOne.GetType().Name); // <>f__AnonymousType0`2

var instanceTwo = new {Id = 42, Name = "Mikhail"};
Console.WriteLine(instanceTwo.GetType().Name); // <>f__AnonymousType0`2

// Равенство и эквивалентность экземпляров анонимных типов
Console.WriteLine(instanceOne == instanceTwo); // ?
Console.WriteLine(ReferenceEquals(instanceOne, instanceTwo)); // ?
Console.WriteLine(instanceOne.Equals(instanceTwo)); // ?

// Поддерживается конструкция with
var instanceThree = instanceOne with { Name = "Eugene" };
Console.WriteLine(instanceThree); // { Id = 42, Name = Eugene }

// Использование анонимных типов в expression tree LINQ-выражений
var client = GetClient(Guid.NewGuid());
var tariffs = GetAvailableTariffs();

var options = tariffs
  .Where(t => t.IsPremium)
  .Select(t => new
  { 
    ClientId = client.Id,
    ClientName = client.Name,
    TariffId = t.Id,
    TariffName = t.Name
  }).ToArray();

Console.WriteLine(options.Any() ?
  $"\n{options.Length} option(-s) found:"
  : "There are no available options for this client");

foreach (var option in options)
{ 
  Console.WriteLine($"Client: {option.ClientName}, tariff: {option.TariffName}");
}

Client GetClient(Guid id)
{
  return new Client(id, "Olga Reshetova", true);
}

IEnumerable<Tariff> GetAvailableTariffs()
{
  return new[]
  {
    new Tariff(Guid.NewGuid(), "Basic", false),
    new Tariff(Guid.NewGuid(), "Standard", false),
    new Tariff(Guid.NewGuid(), "Pro", false),
    new Tariff(Guid.NewGuid(), "Premium", true),
    new Tariff(Guid.NewGuid(), "VIP", true),
  };
}