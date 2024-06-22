### 24. Логирование и сбор метрик сервисов
- назначение логов и метрик
- настройка провайдера логирования в коде сервиса
- настройка публикации метрик в коде сервиса
- анализ логов и метрик сторонними инструментами

#### Практика
1. Настройте логирование во всех сервисах сервисах проекта
   - обращение в каждый эндпоинт каждого контроллера со всеми параметрами
   - вызов публичных методов сервисов Application Layer
   - результат выполнения публичных методов Application Layer
2. Настройте Seq для визуализации логов
3. Настройте публикацию метрик в сервисах проекта:
   - стандартные метрики ASP.NET Core во всех проектах
   - counter, показывающий количество вызовов метода создания ЭПБ
   - counter, показывающий количество ошибок при создании ЭПБ
4. Настройте Prometheus для агрегации метрик
5. Настройте Grafana для визуализации метрик. Для каждого сервиса должен быть настроен отдельный дашборд,
содержащий графики продуктовых метрик, а также наиболее важные инфраструктурные графики:
   - dotnet_total_memory_bytes
   - process_cpu_num_threads
   - dotnet_collections_count_total
   - aspnetcore_healthcheck_status

#### Домашнее задание
1. Ознакомьтесь с [документацией](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-8.0) по основам логирования в ASP.NET Core
2. Ознакомьтесь с документацией по [настройке](https://docs.datalust.co/docs/microsoft-extensions-logging) и [возможностям](https://docs.datalust.co/docs/the-seq-query-language) Seq
3. Изучите документацию по [настройке](https://prometheus.io/docs/prometheus/latest/installation/) Prometheus и [использованию](https://github.com/prometheus-net/prometheus-net) библиотеки prometheus-net
4. Изучите документацию по [настройке](https://grafana.com/docs/grafana/latest/setup-grafana/) Grafana и [интеграции](https://grafana.com/docs/grafana/latest/datasources/prometheus/) её с Prometheus
5. Завершите настройку логирования и метрик согласно заданиям в разделе "Практика"
