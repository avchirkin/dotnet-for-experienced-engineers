### 25. Тестирование .NET-приложений
- виды тестирования приложений
- юнит-тестирование
- проектирование юнит-тестов
- использование моков для внешних зависимостей
- проектирование интеграционных тестов
- организация сквозного процесса тестирования приложений

#### Практика
1. Написать тест Character_IsAlive_Calculates_Correctly в CharacterTests
2. Написать юнит-тесты для метода Character.Defend
3. Произвести рефакторинг класса Session с целью повышения тестируемости логики процесса сражения
4. Написать юнит-тест в AccountsServiceTests, проверяющий, что при вызове метода GetAccountByNumber возвращается счёт с
корректным Number, а соответствующий метод репозитория вызывается ровно один раз
5. Написать интеграционный тест в AccountsTests, проверяющий получение корректного счёта по переданному номеру
6. Написать интеграционный тест в AccountsTests, проверяющий, что попытка получения счёта по несуществующему в системе
номеру приведёт к ответу 404

#### Домашнее задание
1. Изучить ресурсы по основам тестирования:
   - [краткая выжимка по теории тестирования ПО](https://habr.com/ru/articles/587620/)
   - [юнит-тестирование в .NET](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)
   - [интеграционное тестирование в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0)
   - [книга](https://www.ozon.ru/category/printsipy-yunit-testirovaniya-horikov-vladimir) Владимира Хорикова "Принципы юнит-тестирования"
   - [видео](https://www.youtube.com/watch?v=LkrqqpkKIXE) доклада Владимира Хорикова "Принципы юнит-тестирования"
   - [пирамида тестирования](https://habr.com/ru/articles/788212/)
   - [тестовая сота](https://testengineer.ru/testing-pyramid/)
2. Почитать [документацию](https://docs.nunit.org/articles/nunit/intro.html) библиотеки NUnit
3. Почитать [документацию](https://nsubstitute.github.io/help/getting-started/) библиотеки NSubstitute
4. Изучить [статью](https://www.lambdatest.com/blog/nunit-vs-xunit-vs-mstest/) о сравнении наиболее популярных библиотек тестирования в .NET
5. Определить оптимальную стратегию тестового покрытия сервисов проекта ("пирамида", "сота")
6. Покрыть все сервисы проекта тестами, согласно выбранной стратегии покрытия
