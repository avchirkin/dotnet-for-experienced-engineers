using Practice;

var nomenclature = new Nomenclature();

// 1. Вывести товар с самой высокой ценой
var maxPriceRecord = nomenclature.PriceHistory
    .Where(item => item.Value.History.Count > 0)
    .ToDictionary(
        kvp => kvp.Key,
        kvp => kvp.Value.History.Max(item => item.Price))
    .OrderByDescending(kvp => kvp.Value)
    .FirstOrDefault();

var maxPriceItem = nomenclature.Items.FirstOrDefault(item => item.Id.Equals(maxPriceRecord.Key));
Console.WriteLine($"ID: {maxPriceItem?.Id}, Name: {maxPriceItem?.Name}, Price: {maxPriceRecord.Value}");

// 2. Вывести список товаров категории "Товары для спорта" в порядке по убыванию

// 3. Вывести самый дешевый товар категории "Офисные товары и канцелярия"

// 4. Вывести товары, у которых отсутствует цена в истории цен

// 5. Вывести товары, у которых цена менялась наибольшее количество раз

// 6. Вывести товары, у которых цена менялась наименьшее количество времени назад

// 7. Вывести день, в который произошло наибольшее количество изменений цен товаров, и количество таких изменений

// 8. Вывести перечень категорий с их средней ценой за товар

// 9. Вывести товары категорий "Игрушки" и "Товары для спорта" дороже 500 рублей

