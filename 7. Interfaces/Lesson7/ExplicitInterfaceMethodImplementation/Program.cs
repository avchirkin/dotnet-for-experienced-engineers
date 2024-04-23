using ExplicitInterfaceMethodImplementation;

Plane plane = new Plane();
plane.Move(); // ВОПРОС - какой из методов Move будет вызван?

// Экземпляр класса Plane можно использовать и как IMovable, и как IFlyable.
// Таким образом, мы можем трактовать "самолёт" как "двигающийся" объект и как "летающий" объект.
((IMovable)plane).Move(); // "Moving through the landing zone"
((IFlyable)plane).Move(); // "Moving to the target airport"