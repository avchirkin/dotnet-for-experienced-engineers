namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменной типа string (строка).
            // Значение в месте инициализации ещё не присвоено, использовать такую переменную нельзя.
            string hello;
            //Console.WriteLine(hello); // Это не сработает
            
            // Присвоили переменной значение через оператор =, после чего можем вывести значение в консоль.
            hello = "Hello, group!";
            Console.WriteLine(hello); // Hello, group!

            // Значение переменной можно переопределять.
            hello = "Hi, group!";
            Console.WriteLine(hello); // Hi, group!

            // Одной строкой допустимо объявлять сразу более чем одну переменную указанного типа.
            int stepsYesterday, stepsToday;
            stepsYesterday = 5200;
            stepsToday = 8950;

            // В метод можно передавать выражение. В качестве значения аргумента будет выступать его результат.
            Console.WriteLine(stepsToday + stepsYesterday);

            // Также допустимо присваивать значения более чем одной переменной в одну строку.
            int windSpeed = 5, temperature = -3;
            
            // Метод WriteLine имеет вариацию (перегрузку), принимающую шаблонизированную строку и параметры
            // для её заполнения.
            Console.WriteLine("Wind: {0}, temperature: {1}", windSpeed, temperature);

            // Компилятор в большинстве случаев умеет выводить тип значения переменной самостоятельно.
            // Для использования механизма выведения типа вместо типа переменной нужно указать ключевое слово var.
            var someString = "I'm a string";
            Console.WriteLine(someString);

            var someInt = 1;
            Console.WriteLine(someInt);

            /* При этом, тип у переменной имеется, так как компилятору известен тип правой части выражения
             * (достаточно навести на нее курсором в IDE, чтобы это увидеть), 
             * поэтому следующая операция присвоения невозможна:*/
            // someString = someInt; // Error: Cannot impilictly convert type 'int' to 'string'
        }
    }
}
