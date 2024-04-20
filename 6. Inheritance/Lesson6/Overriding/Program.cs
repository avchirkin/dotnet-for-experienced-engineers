using Overriding;

// Vehicle armored = new Vehicle(); // Нельзя создать экземпляр абстрактного класса.
// ArmoredVehicle armored = new ArmoredVehicle(Nation.GLA); // Нельзя создать экземпляр абстрактного класса.

Vehicle scorpionOne = new ScorpionTank();
Console.WriteLine(scorpionOne);

ArmoredVehicle scorpionTwo = new ScorpionTank();
Console.WriteLine(scorpionTwo);

ScorpionTank scorpionThree = new ScorpionTank();
Console.WriteLine(scorpionThree);

