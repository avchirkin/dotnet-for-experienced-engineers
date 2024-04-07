#region Цикл for
// ПРИМЕР - выводим поэлементно массив чисел с помощью цикла for

Console.WriteLine("Enter several words splitted with whitespace (e.g., 'hello group how are you')");
var numbersString = Console.ReadLine() ?? string.Empty;

// Разделяем строку по пробелам и создаём массив чисел
var numbers = numbersString.Split();

/* цикл for служит для гибкой настройки граничных условий цикла и его шага
 *      int i = 0 - инициализация счётчика. Обязательная часть
 *      i < numbers.Length - условие цикла - пока оно выполняется (равно true), цикл будет выполнять
 * новую итерацию. Обязательная часть
 *      i++ - инкремент счётчика. Необязательная часть (счётчик можно наращивать в теле цикла)
 * 
*/
Console.WriteLine("for - вывод элементов массива");
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

for (int i = 0; i < numbers.Length;)
{
    Console.WriteLine(numbers[i++]);
}


// ПРИМЕР - настраиваем начальное значение счётчика и размер шага цикла for

// Выведем каждую третью букву слова.
// Для этого установим начальное значение счётчика в 2 вместо 0, а шаг будем наращивать сразу на 3
Console.WriteLine("for - вывод каждого третьего символа");
var word = "Somnambula";
for (var i = 2; i < word.Length; i += 3) // ВОПРОС - почему не 'i <= word.Length'?
{
    Console.Write(word[i]);
}
#endregion

#region Цикл while
// цикл while полезен в случаях, когда необходимо выполнять действие до выполнения какого-либо условия.


/* ПРИМЕР - посимвольный вывод строки с помощью цикла while
 *   enumerator - содержит объект, "умеющий" обходить коллекцию элементов по заданному алгоритму;
 *   для класса string это простой посимвольный обход.
 *   enumerator.MoveNext() возвращает true до тех пор, пока мы не обошли все символы в строке word.
 *   После обхода всех символов метод вернёт false, и цикл прервётся.
*/
Console.WriteLine("While - посимвольный вывод");
var enumerator = word.GetEnumerator();
while(enumerator.MoveNext())
{
    Console.Write(enumerator.Current);
}


// ПРИМЕР - наивная реализация возведения в степень с помощью цикла while 
Console.WriteLine("Введите число, которое хотите возвести в степень");
var number = int.Parse(Console.ReadLine()
    ?? throw new InvalidOperationException("Введите целое число!"));

Console.WriteLine("Введите показатель степени");
var power = int.Parse(Console.ReadLine()
    ?? throw new InvalidOperationException("Введите целое число!"));

var result = number;
var counter = power;
while (counter > 1) // ВОПРОС - почему 'больше единицы'?
{
    result *= number;
    counter--; // Оператор пост-декремента -- синонимичен выражению 'counter = counter - 1'
}

Console.WriteLine($"While - {number} в степени {power} равно {result}");
// НА БУДУЩЕЕ
// Возведение числа в степень проще осуществлять с помощью метода Pow класса Math:
// var result = Math.Pow(2, 3);
#endregion

#region Цикл do-while
/* цикл do-while аналогичен циклу while, однако проверяет условие ПОСЛЕ выполнения блока.
 * Таким образом, блок кода, в отличие от цикла while, ТОЧНО выполнится хотя бы один раз.
 */
// ПРИМЕР - наивная реализация возведения в степень с помощью цикла do-while
result = number;
counter = power;
do
{
    result *= number;
} while (counter-- > 1);
Console.WriteLine($"Do-While - {number} в степени {power} равно {result}");
#endregion

#region Цикл foreach
/* цикл foreach служит для обхода коллекций по принципу <для каждого X в коллекции Y выполни действие>.
 * О внутреннем устройстве этого механизма
 * мы поговорим в занятии, посвящённом коллекциям и интерфейсу IEnumerator.
 * Обратите внимание на отсутствие явного счётчика и условия.
 */
// ПРИМЕР - обход элементов массива с помощью цикла foreach.
// var num - значение элемента массива, numbers - сам массив.
foreach(var num in numbers)
{
    Console.Write(num);
}
#endregion

// ЗАДАНИЕ - написать консольное приложение, выбирающее максимальное и минимальное число из
// чисел, введенных пользователем через пробел. Привести решения с использованием ВСЕХ видов циклов.