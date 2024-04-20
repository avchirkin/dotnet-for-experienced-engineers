using InheritanceBasics;

// Создаём объект базового класса Vehicle - требуются все параметры, запрашиваемые конструктором
Vehicle battleBus = new Vehicle("Battle bus", VehicleType.Civil, Nation.GLA);
Console.WriteLine(battleBus);

// Создаём объект дочернего класса ArmoredVehicle как объект базового класса Vehicle
Vehicle scorpion = new ArmoredVehicle("Scorpion Tank", Nation.GLA);
// scorpion.UpgradeArmor(0.25f); // Cannot resolve symbol 'UpgradeArmor' - не можем вызвать метод дочернего класса
Console.WriteLine(scorpion);

// Создаём объект дочернего класса ArmoredVehicle
ArmoredVehicle crusader = new ArmoredVehicle("Crusader Tank", Nation.USA);
Console.WriteLine(crusader);

Console.WriteLine();

crusader.UpgradeArmor(0.25f); // Можем вызвать метод дочернего класса, так как переменная имеет нужный тип
Console.WriteLine(crusader);

// crusader.ApplyDamage(0.25f); // Cannot access protected method
// Console.WriteLine(crusader);
