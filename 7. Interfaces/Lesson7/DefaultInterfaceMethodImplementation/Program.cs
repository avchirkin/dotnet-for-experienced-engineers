// See https://aka.ms/new-console-template for more information

using DefaultInterfaceMethodImplementation;

Car car = new Car();
car.SetSpeed(15.0f); // Ок - вызовется метод класса, унаследованный от интерфейса
// car.SetDirection(65.0f); // Ошибка - такого метода нет в классе Car
((IMovable)car).SetDirection(1000.0f); // Ок - используем дефолтную имплементацию в интерфейсе

Plane plane = new Plane();
plane.SetSpeed(900.0f); // Ок - вызовется метод класса, унаследованный от интерфейса
((IMovable)plane).SetDirection(1000.0f); // ВОПРОС - что выйдет в консоль?
((IFlyable)plane).SetDirection(1000.0f); // ВОПРОС - что выйдет в консоль?

