namespace SimpleArithmeticOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // сложение
            var first = 15;
            var second = 5;
            Console.WriteLine(first + second); // 20

            // вычитание
            Console.WriteLine(first - second); // 10

            // умножение
            Console.WriteLine(first * second); // 75

            // деление
            Console.WriteLine(first / second); // 3

            // остаток от деления
            Console.WriteLine(first % second); // 0

            // битовый сдвиг
            var two = 2;
            Console.WriteLine(two >> 1); // 0010 >> 1 = 0001 = 1
            Console.WriteLine(two << 1); // 0010 << 1 = 0100 = 4

            // побитовые операции
            Console.WriteLine(two & 1); // 0010 & 0001 = 0000 = 0
            Console.WriteLine(two | 1); // 0010 | 0001 = 0011 = 3
            Console.WriteLine(two ^ 1); // 0010 ^ 0001 = 0011 = 3

            // округление
            int result = 5 / 2;
            Console.WriteLine(result); // 2 - целые типы округляются по умолчанию до меньшего

            var rounded = Math.Round(5 / 2d);
            Console.WriteLine(rounded); // 2 - до меньшего целого

            var toFloor = Math.Floor(5 / 2d);
            Console.WriteLine(toFloor); // 2 - до меньшего целого

            var toCeiling = Math.Ceiling(5 / 2d);
            Console.WriteLine(toCeiling); // 3 - до большего целого
        }
    }
}
