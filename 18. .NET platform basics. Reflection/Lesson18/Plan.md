### 18. Возможности платформы .NET
- устройство платформы .NET. Среда выполнения (CLR)
- основные возможности платформы
- жизненный цикл кода. Roslyn, IL, JIT
- сборка мусора. Garbage collector
- понятие неуправляемого ресурса
- детерминированная и недетерминированная финализация
- паттерн Disposable
- оператор using

#### Практика
Реализовать класс Disposer, имеющий публичный метод Wrap, который принимает на вход некоторый Action<T>, где T - IDisposable.
Метод должен запускать переданный Action<T> и убедиться, что для T реализован вызов Dispose в конце метода любым доступным
способом.

#### Домашнее задание
1. Изучить документацию по работе GC:
   - [понятие](https://learn.microsoft.com/en-us/dotnet/standard/managed-code) управляемого и неуправляемого кода
   - [основы](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)
   - [SOH/LOH](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/large-object-heap)
   - [режимы работы GC](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/workstation-server-gc)
2. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-idisposable) по использованию паттерна IDisposable и оператора using
3. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/finalizers) по финализаторам
4. Ознакомиться с [книгой](https://www.ozon.ru/product/upravlenie-pamyatyu-v-net-dlya-professionalov-kokosa-konrad-1515023715) Конрада Кокоса "Pro .NET Memory Management"