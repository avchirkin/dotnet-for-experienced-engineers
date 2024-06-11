### 21. Фреймворк ASP.NET Core
- устройство и назначение ASP.NET Core
- виды приложений, разрабатываемых на базе ASP.NET Core
- структура пайплайна выполнения запроса
- контейнер управления зависимостями. Middleware
- ASP.NET Core Minimal API. Роутинг
- реализация HTTP-эндпоинтов в контроллерах

#### Практика
1. Спроектировать и реализовать web API для проектного задания:
   - API учёта ЭПБ
       - добавление нового ЭПБ
       - изменение статуса ЭПБ (включая деактивацию)
       - получение информации о конкретном ЭПБ
   - API счёта ЭПБ
       - привязывание ЭПБ к счёту
       - пополнение счёта ЭПБ
       - получение информации об остатке денежных средств на счету ЭПБ
       - списание денежных средств со счёта ЭПБ
   - API тарифов
       - получение списка тарифов
       - получение информации о конкретном тарифе
       - привязывание тарифа к ЭПБ
   - API поездок
       - получение информации о поездках по ЭПБ
2. Пользуясь доменными сущностями, спроектированными в ходе Занятия 19, реализуйте создание экземпляров сущностей в БД
через интерфейс Swagger. Реализуйте сервисный слой (на данный момент - без какой-либо бизнес-логики). Помните про
использование отдельных моделей (DTO) для создания сущностей и получения информации из сервиса. 


#### Домашнее задание
1. Изучить документацию по ASP.NET Core
   - [разводящая страница](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
   - [общее устройство фреймворка](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-8.0)
   - [пайплайн выполнения запроса](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0)
   - [фильтры](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-8.0)
   - [middleware](https://habr.com/ru/companies/otus/articles/528692/)
   - [Minimal API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0)
   - [контроллеры](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0)
   - [DI-контейнер](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0)
   - [аутентификация](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-8.0)
   - [авторизация](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-8.0)

2. Доделать задание из блока "Практика"
3. Ознакомиться с [книгой](https://www.ozon.ru/product/asp-net-core-v-deystvii-318590549) Эндрю Лока "ASP.NET Core в действии"
