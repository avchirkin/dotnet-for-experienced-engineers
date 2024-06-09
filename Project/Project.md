## Система учёта и пополнения электронных проездных билетов

### Функциональные требования

- FN1. Система должна предоставлять возможность учёта электронных проездных билетов (ЭПБ) для наземного транспорта и метро:
   - FN1.1. ЭПБ включает в себя идентификационную информацию (номер ЭПБ), информацию о выбранном тарифе, ограничениях срока
   использования (если имеется, согласно тарифу), информацию о привязанном счёте и остатке средств на нём
   - FN1.2. Остаток денежных средств на счету ЭПБ учитывается в рублях, не может быть отрицательным и не может превышать
   15_000 рублей
   - FN1.3. В случае истечения срока действия ЭПБ система должна помечать его как неактивный. Переактивация возможна
   пролонгацией текущего тарифа или изменением текущего тарифа на тариф без ограничения срока использования. Операции
   пополнения счёта и оплаты проезда по неактивным ЭПБ должна быть запрещена системой
   - FN1.4. Система должна предоставлять возможность деактивации ЭПБ - приостановки его использования, в том числе - если
   срок действия ЭПБ ещё не истёк
   - FN1.5. Возможные состояния ЭПБ:
     - NotActivated (новые ЭПБ, не привязанные к тарифу)
     - Active (ЭПБ с неистёкшим сроком действия)
     - Blocked (ЭПБ, срок действия которого истёк, либо деактивированный по другим причинам)

- FN2. Система должна предоставлять возможность добавления новых ЭПБ
     - FN2.1. При добавлении ЭПБ его статус должен устанавливаться в NotActivated
     - FN2.2. При добавлении ЭПБ к нему привязывается счёт с нулевым остатком
       
- FN3. Система должна предоставлять возможность пополнения счёта ЭПБ
     - FN3.1. Сумма пополнения счёта должна быть не менее 10 и не более 15_000 рублей
     - FN3.2. Сумма средств на счету после пополнения не должна превышать 15_000 рублей, в противном случае пополнение
     должно быть отклонено системой с понятной для пользователя нотификацией

- FN4. Система должна предоставлять возможность активации одного из тарифов на ЭПБ:
     - "1 день" - срок действия 24 часа с момента активации, цена активации - 500 рублей
       - цена проезда на наземном транспорте - бесплатно в пределах срока действия
       - цена проезда на метро - бесплатно в пределах срока действия
     - "3 дня" - срок действия 48 часов с момента активации, цена активации - 1350 рублей
       - цена проезда на наземном транспорте - бесплатно в пределах срока действия
       - цена проезда на метро - бесплатно в пределах срока действия
     - "Месячный" - срок действия 30 дней с момента активации, цена активации - 5000 рублей
       - цена проезда на наземном транспорте - бесплатно в пределах срока действия
       - цена проезда на метро - бесплатно в пределах срока действия
     - "Студенческий" - срок действия 1 год с момента активации, свободное пополнение
       - цена проезда на наземном транспорте - 25 рублей
       - цена проезда на метро - 40 рублей
     - "С пополнением" - срок действия бессрочный, свободное пополнение
       - цена проезда на наземном транспорте - 40 рублей
       - цена проезда на метро - 55 рублей
     - FN4.1. Единовременно к ЭПБ может быть привязан только один тариф
     - FN4.2. Смена тарифа ЭПБ возможна не чаще одного раза в течение календарных суток
     - FN4.3. При смене тарифа система должна проверять наличие требуемого для активации тарифа количества денежных
     средств на счету ЭПБ. В случае нехватки денежных средств операция смены тарифа должна отклоняться
     - FN4.4. После смены тарифа новый тариф должен начать своё действие не ранее 00 часов следующего календарного дня

- FN5. Система должна предоставлять возможность списания денежных средств со счета ЭПБ
     - FN5.1. Сумма списания должна соответствовать установленному тарифу и типу общественного транспорта, на котором
     была совершена поездка
     - FN5.2. Система должна отслеживать точки оплаты проезда с помощью ЭПБ. В случае, если оплата была произведена в
     одной точке (терминале) с разницей во времени, не превышающей 10 минут, каждая оплата, кроме первой, должна иметь 
     коэффициент 1.2 относительно стоимости единичной поездки согласно тарифу и виду транспорта.
     Повторная оплата в течение 10 минут для ЭПБ с тарифами "1 день", "3 дня" и "Месячный" должна рассчитываться, исходя
     из стоимости поездки, аналогичной тарифу "С пополнением" (с учётом повышающего коэффициента).

- FN6. Система должна предоставлять возможность построения отчетов
     FN6.1. Количество проданных ЭПБ за указанный период с возможностью фильтрации по тарифу
     FN6.2. Количество денежных средств, внесённых на счета ЭПБ в указанный период с возможностью фильтрации по тарифу
     FN6.3. Остаток денежных средств на счетах ЭПБ с разбивкой по тарифам
     FN6.4. Количество поездок за указанный период в разрезе точки оплаты и тарифа
     FN6.5. Количество денежных средств, списанных со счетов в рамках поездок в разрезе точки оплаты и тарифа
     FN6.6. Количество деактивированных ЭПБ за период
     FN6.7. Количество ЭПБ в разрезе их текущих статусов на текущий момент времени

### Нефункциональные требования
- NF1. Система должна использовать в качестве хранилищ БД Postgres
- NF2. Система должна использовать подходы и средства повышения надёжности там, где это имеет смысл (кеши, ретраи, асинхронные интеграции и пр.)
- NF3. Система должна быть физически декомпозирована согласно субдоменам предметной области
- NF4. Основные сценарии системы должны быть покрыты модульными и интеграционными тестами
- NF5. Все сервисы системы должны предоставлять API в формате OpenAPI (Swagger)