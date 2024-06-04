### 19. Работа с хранилищами данных - интеграция с БД
- возможности интеграции кода с БД
- устройство и возможности EntityFramework
- подключение провайдера данных в коде приложения
- Code First vs DB First
- Code First. Подготовка контекста и моделей
- Code First. Миграции
- выполнение запроса на выборку
- выполнение вставки/обновления данных в БД
- отслеживание изменений
- интерфейс IQueryable
- анализ текста запроса, сгенерированного провайдером
- navigation properties. Отношения "one-to-one", "one-to-many", "many-to-many"
- производительность запросов

#### Практика
Доработать ProductsService:
- добавить метод, выполняющий поиск товаров по наименованию
- добавить колонку created_date во все сущности, заполнять её текущими датой и временем
- добавить метод удаления характеристики по её наименованию
- добавить метод, ищущий характеристики, которые не привязаны ни к одному товару

#### Домашнее задание
1. Изучить статьи и документацию по EntityFramework (включая дочерние страницы):
   - [IQueryable и деревья выражений](https://habr.com/ru/articles/256821/)
   - [DbContext](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/)
   - [настройка entity](https://learn.microsoft.com/en-us/ef/core/modeling/)
   - [отношения "one-to-one", "one-to-many", "many-to-many"](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
   - [Code First и миграции](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
   - [DB First (scaffolding)](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)
   - [трекинг запросов](https://learn.microsoft.com/en-us/ef/core/change-tracking/)
   - [запросы на чтение](https://learn.microsoft.com/en-us/ef/core/querying/)
   - [запросы на запись](https://learn.microsoft.com/en-us/ef/core/saving/)
2. Разработать сущности и БД для хранения данных системы пополнения электронных проездных билетов (см. Project.md)
3. Ознакомиться с [книгой](https://www.ozon.ru/category/entity-framework-core-in-action/) Д. Смита "Entity Framework Core In Action"
