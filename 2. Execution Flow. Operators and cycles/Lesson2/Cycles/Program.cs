// Пользователь вводит несколько чисел, разделённых пробелом
Console.WriteLine("Enter several words splitted with whitespace (e.g., 'hello group how are you')");
var numbersString = Console.ReadLine() ?? string.Empty;

// Разделяем строку по пробелам и создаём массив чисел
var numbers = numbersString.Split();

#region Цикл for
/* цикл for служит для гибкой настройки граничных условий цикла и его шага
 *      int i = 0 - инициализация счётчика. Обязательная часть
 *      i < numbers.Length - условие цикла - пока оно выполняется (равно true), цикл будет выполнять
 * новую итерацию. Обязательная часть
 *      i++ - инкремент счётчика. Необязательная часть (счётчик можно наращивать в теле цикла)
 * 
*/
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

// Выведем каждую третью букву слова.
// Для этого установим начальное значение счётчика в 2 вместо 0, а шаг будем наращивать сразу на 3
var word = "Somnambula";
for (var i = 2; i < word.Length; i += 3)
{
    Console.Write(word[i]);
}
#endregion

#region Цикл while
#endregion

#region Цикл do-while
#endregion

#region Цикл foreach
#endregion