### 13. Делегаты и события
- понятие делегата
- определение делегата
- классы Func и Action
- цепочка делегатов
- method group
- понятие события
- определение события
- подписка на событие
- паттерн Observer

#### Практика
Реализовать метод, выполняющий валидацию номеров документов (ИНН, паспорта, СНИЛС) и выводящий провалидированную
строку в лог вида "<Тип документа> № <номер документа>". В случае, если валидация не прошла, должно выводиться
сообщение для пользователя о вводе некорректных данных. Логику фильтрации нужно передавать в метод в виде функции
фильтрации. Все функции фильтрации вынести в отдельные классы валидаторов (по валидатору на каждый документ).

#### Домашнее задание
1. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/) по делегатам
2. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/) по событиям
3. Реализовать сервис открытия банковских счетов AccountService с методом CreateAccount, создающим счёт указанному
пользователю. При вызове метода CreateAccount должен запускаться ряд действий:
- проверка того, что клиент не находится в "чёрном списке";
- проверка того, что у клиента не существует счёта того же типа;
- регистрация счёта в учётной системе;
- отправка нотификации пользователю на почту.

  Используя MulticastDelegate, свяжите эти действия в одну цепочку. Каждому действию в сервисе AccountService сопоставьте
  отдельный метод (логику прописывать не нужно, достаточно выводить в консоль сообщения вида "Проверка клиента на нахождение
  в 'чёрном списке'", "Проверка наличия существующего счёта клиента того же типа" и т.д.). При вызове метода CreateAccount
  в консоли должны отражаться все действия, сопоставленные с делегатом.
4. Написать класс-обёртку ObservableList<T> для List<T>, оповещающую о добавлении нового элемента в список и удалении элемента
из списка