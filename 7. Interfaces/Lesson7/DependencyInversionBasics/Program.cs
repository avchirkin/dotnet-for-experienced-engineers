using DependencyInversionBasics;

var bus = new Bus(route: 15, startingPosition: 97.4f);
bus.CurrentPosition = 124.3f;

var plane = new Plane(route: 467, departurePoint: "SVO");
plane.CurrentLocation = "LED";

var fitnessTracker = new FitnessTracker("Vladimir");
fitnessTracker.IncreaseSteps(1520);

var tracer = new StatisticsTracer();
tracer.Trace(bus);
tracer.Trace(plane);
tracer.Trace(fitnessTracker);