
using InterfaceBasics;

BattleMasterTank battleMaster = new BattleMasterTank();
battleMaster.Move(42); // Moving to waypoint 42...
Console.WriteLine(battleMaster.MaxSpeed); // 70
Console.WriteLine(battleMaster.ArmorThickness); // 120

// IMovable movable = new IMovable(); // Ошибка! Нельзя создать экземпляр интерфейса

// Неявное приведение к типу интерфейса
IMovable movableBattleMaster = new BattleMasterTank();
movableBattleMaster.Move(42); // Moving to waypoint 42...
Console.WriteLine(movableBattleMaster.MaxSpeed); // 70
// Console.WriteLine(movableBattleMaster.ArmorThickness); // Ошибка! В интерфейсе IMovable нет такого свойства

// BattleMasterTank anotherBattleMaster = movableBattleMaster; // Невозможно преобразовать из интерфейса в класс
BattleMasterTank anotherBattleMaster = (BattleMasterTank)movableBattleMaster; // А вот так - можно
anotherBattleMaster.Move(42);