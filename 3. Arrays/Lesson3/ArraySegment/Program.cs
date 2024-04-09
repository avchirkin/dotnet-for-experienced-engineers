// ПРИМЕР - чтение данных из некоторого большого массива-"источника" по батчам

var batchSize = 1024;
var hugeArray = new byte[batchSize * 128];

// Первый подход - копируем 1 Кб данных в отдельный массив и работаем с ним (аллокация нового массива!)
var newArray = new byte[batchSize];
Array.Copy(hugeArray, newArray, batchSize);
Console.WriteLine(newArray.Length);

// Второй подход - используем ArraySegment, хранящий под капотом ссылку на исходный массив (аллокации нового массива нет)
var arraySegment = new ArraySegment<byte>(hugeArray, 0, batchSize);
Console.WriteLine(arraySegment.Count);