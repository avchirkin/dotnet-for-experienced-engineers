using PolymorphicBehavior;

Vehicle v1 = new Vehicle();
v1.Print(); // ?

Vehicle v2 = new ArmoredVehicle();
v2.Print(); // ?

Vehicle v3 = new ScorpionTank();
v3.Print(); // ?

ArmoredVehicle v4 = new ArmoredVehicle();
v4.Print(); // ?

ArmoredVehicle v5 = new ScorpionTank();
v5.Print(); // ?

ScorpionTank v6 = new ScorpionTank();
v6.Print(); // ?

